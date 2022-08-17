﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Stores;
using ProjectMateTask.Services.AppInfrastructure;

namespace ProjectMateTask.Data;

public class DbInitializer:IDbInitializer
{
    private readonly ProjectMateTaskDb _db;
    
    private readonly ILogger<DbInitializer> _logger;

    public DbInitializer(ProjectMateTaskDb db,ILogger<DbInitializer> logger)
    {
        _db = db;
        
        _logger = logger;
    }
    /// <summary>
    /// Инициализация Бд
    /// </summary>
    public async Task InitializeAsync()
    {
        var loggerTimer = Stopwatch.StartNew();
     
        byte errorCounter = 0;
        
        _logger.LogInformation("Инициализация базы данных...");
        
        _logger.LogInformation("Миграция базы данных...");

        try
        {
            await _db.Database.MigrateAsync().ConfigureAwait(false);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e,"Ошибка миграции базы данных.");
            errorCounter++;
        }
        
        _logger.LogInformation("Миграция базы данных выполнена c {0} ошибками за {1} мс", errorCounter, loggerTimer.ElapsedMilliseconds);

        if (!await _db.ClientStatus.AnyAsync())
        {
            try
            {
                await InitializeClientTypesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Ошибка инициализации типов клиентов в бд.");
                errorCounter++;
            }
           
        }

        if (!await _db.ProductTypes.AnyAsync())
        {
            
            try
            {
                await InitializeProductTypeAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Ошибка инициализации типов продуктов в бд.");
                errorCounter++;
            }
        }
        
        _logger.LogInformation("Инициализация базы данных выполнена c {0} за {1} c", errorCounter, loggerTimer.Elapsed.TotalSeconds);
    }

    /// <summary>
    /// Инициализация тестовых данных в бд
    /// </summary>
    public async Task InitializeTestDataAsync()
    {
        var loggerTimer = Stopwatch.StartNew();
        
        _logger.LogInformation("Инициализация тестовых данных в базе данных...");

        byte errorCounter = 0;
        
        try
        {
            await InitializeTestProductsAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e,"Ошибка инициализации тестовых продуктов в бд.");
            errorCounter++;
        }
        
        try
        {
            await InitializeTestManagersAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e,"Ошибка инициализации тестовых менеджеров в бд.");
            errorCounter++;
        }
      
        try
        {
            await InitializeTestClientsAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e,"Ошибка инициализации тестовых клиентов в бд.");
            errorCounter++;
        }
        
        _logger.LogInformation("Инициализация тестовых данных выполнена с {0} ошибками за {1} c",errorCounter , loggerTimer.Elapsed.TotalSeconds);
    }


    /// <summary>
    /// Откат базы данных к исходному состоянию
    /// </summary>
    public async Task RebuildDataBaseAsync()
    {
        var loggerTimer = Stopwatch.StartNew();
        
        
        _logger.LogInformation("Пересоздание базы данных...");
        
        _logger.LogInformation("Удаление старой базы данных...");

        try
        {
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            _logger.LogInformation("Удаление базы данных выполнено за {0} мс", loggerTimer.ElapsedMilliseconds);
        }
        catch (Exception e)
        {
            _logger.LogError(e,"Ошибка удаления базы данных.");
            return;
        }
        
        await InitializeAsync();
        
        _logger.LogInformation("Пересоздание базы данных выполнено за {0} c", loggerTimer.Elapsed.TotalSeconds);
    }
    
    
    private const int ClientTypesCount = 2;
    private ClientStatus[] _clientTypes;
    
    /// <summary>
    /// Инициализация типов клиентов
    /// </summary>
    private async Task InitializeClientTypesAsync()
    {
        var loggerTimer = Stopwatch.StartNew();
        
        _logger.LogInformation("Инициализация типов клиентов ...");
        
        _clientTypes = new ClientStatus[ClientTypesCount]
        {
            new ClientStatus{Name = "Ключевой"},
            new ClientStatus{Name = "Обычный"}
        };

       await _db.ClientStatus.AddRangeAsync(_clientTypes);
       _db.SaveChanges();
       
       _logger.LogInformation("Инициализация типов клиентов выполнена за {0} мс", loggerTimer.Elapsed.TotalMilliseconds);
    }
    
    private const int ProductTypeCount = 4;
    private ProductType[] _productTypes ;
    
    /// <summary>
    /// Инициализация типов продукта
    /// </summary>
    private async Task InitializeProductTypeAsync()
    {
        var loggerTimer = Stopwatch.StartNew();
        
        _logger.LogInformation("Инициализация типов продуктов ...");
        
        _productTypes = new ProductType[ProductTypeCount]
        {
            new ProductType{Name = "Постоянная лицензия"},
            new ProductType{Name = "Месячная подписка"},
            new ProductType{Name = "Квартальная подписка"},
            new ProductType{Name = "Годовая подписка"}
        };

        await _db.ProductTypes.AddRangeAsync(_productTypes);
        _db.SaveChanges();
        
        _logger.LogInformation("Инициализация типов продуктов выполнена за {0} мс", loggerTimer.Elapsed.TotalMilliseconds);
    }

    private const int TestProductsCount = 20;
    private Product[] _testProducts;
    /// <summary>
    /// Иницилизация тестовых значений продуктов в бд
    /// </summary>
    private async Task InitializeTestProductsAsync()
    {
        var loggerTimer = Stopwatch.StartNew();
        
        Random rnd = new Random();
        
        _logger.LogInformation("Инициализация продуктов ...");
        
        var productTypes = _db.ProductTypes.ToArray();
        
        _testProducts = Enumerable.Range(0, TestProductsCount)
            .Select(i=> new Product
            {
                Name = $"Тестовый продукт #{i}",
                Type = rnd.NextItem(productTypes)
                
            }).ToArray();

        await _db.Products.AddRangeAsync(_testProducts);
         _db.SaveChanges();
        
        _logger.LogInformation("Инициализация продуктов выполнена за {0} мс", loggerTimer.Elapsed.TotalMilliseconds);
    }
    
    
    private const int TestManagersCount = 20;
    private Manager[] _testManagers;
    /// <summary>
    /// Иницилизация тестовых значений продуктов в бд
    /// </summary>
    private async Task InitializeTestManagersAsync()
    {
        var loggerTimer = Stopwatch.StartNew();
        
        _logger.LogInformation("Инициализация менеджеров ...");
        
        _testManagers = Enumerable.Range(0, TestManagersCount)
            .Select(i=> new Manager()
            {
                Name = $"Тестовый менеджер #{i}",
            }).ToArray();
        
        await _db.Managers.AddRangeAsync(_testManagers);
        _db.SaveChanges();
        
        _logger.LogInformation("Инициализация менеджеров выполнена за {0} мс", loggerTimer.Elapsed.TotalMilliseconds);
    }
    
    private const int TestClientsCount = 20;
    private Client[] _testClients;
    /// <summary>
    /// Иницилизация тестовых значений клиентов в бд
    /// </summary>
    private async Task InitializeTestClientsAsync()
    {
        var loggerTimer = Stopwatch.StartNew();
        
        Random rnd = new Random();
        
        _logger.LogInformation("Инициализация клиентов ...");

        var managers = _db.Managers.ToArray();
        
        var clientTypes = _db.ClientStatus.ToArray();

        var products = _db.Products.ToArray();
        
        _testClients = Enumerable.Range(0, TestClientsCount)
            .Select(i=> new Client()
            {
                Name = $"Тестовый клиент #{i}",
                Manager = rnd.NextItem(managers),
                Status = rnd.NextItem(clientTypes),
                Products = GenereteClientsProductsTest(products)
            }).ToArray();
        
         _db.Clients.AddRange(_testClients);
        
        _db.SaveChanges();

        _logger.LogInformation("Инициализация клиентов выполнена за {0} мс", loggerTimer.Elapsed.TotalMilliseconds);
    }

    /// <summary>
    /// Генеарация тестовых значений продуктов для клиентов
    /// </summary>
    /// <returns></returns>
    private Product[] GenereteClientsProductsTest(Product[] dbProducts)
    {
        Random rnd = new Random();
        
        var products = new Product[rnd.Next(0, 10)];

        for (int i = 0; i < products.Length; i++)
        {
            products[i] = rnd.NextItem(dbProducts);
        }

        return products;
    }
}