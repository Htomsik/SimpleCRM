using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.Data;

public class DbInitializer
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
        
        _logger.LogInformation("Инициализация базы данных...");
        
        _logger.LogInformation("Миграция базы данных...");
        
        await _db.Database.MigrateAsync().ConfigureAwait(false);
        
        _logger.LogInformation("Миграция базы данных выполнена за {0} мс", loggerTimer.ElapsedMilliseconds);
        
        
        if(await  _db.ClientStatus.AnyAsync()) return;

        
        await InitializeClientTypesAsync();
        
        await InitializeProductTypeAsync();
        
        _logger.LogInformation("Инициализация базы данных выполнена за {0} c", loggerTimer.Elapsed.TotalSeconds);
    }

    /// <summary>
    /// Инициализация тестовых данных в бд
    /// </summary>
    public async Task InitializeTestDataAsync()
    {
        var loggerTimer = Stopwatch.StartNew();
        
        _logger.LogInformation("Инициализация тестовых данных в базе данных...");
        
        await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
        
        await InitializeTestProductsAsync();
        await InitializeTestManagersAsync();
        await InitializeTestClientsAsync();
        
        _logger.LogInformation("Инициализация тестовых данных выполнена за {0} c", loggerTimer.Elapsed.TotalSeconds);
    }


    /// <summary>
    /// Откат базы данных к исходному состоянию
    /// </summary>
    public async Task RebuildDataBaseAsync()
    {
        var loggerTimer = Stopwatch.StartNew();
        
        _logger.LogInformation("Пересоздание базы данных...");
        
        _logger.LogInformation("Удаление старой базы данных...");
        
        await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
        
        _logger.LogInformation("Удаление старой базы данных выполнена за {0} мс", loggerTimer.ElapsedMilliseconds);

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
       await _db.SaveChangesAsync();
       
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
        await _db.SaveChangesAsync();
        
        _logger.LogInformation("Инициализация типов продуктов выполнена за {0} мс", loggerTimer.Elapsed.TotalMilliseconds);
    }

    private const int TestProductsCount = 100;
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
        await _db.SaveChangesAsync();
        
        _logger.LogInformation("Инициализация продуктов выполнена за {0} мс", loggerTimer.Elapsed.TotalMilliseconds);
    }
    
    
    private const int TestManagersCount = 100;
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
        await _db.SaveChangesAsync();
        
        _logger.LogInformation("Инициализация менеджеров выполнена за {0} мс", loggerTimer.Elapsed.TotalMilliseconds);
    }
    
    private const int TestClientsCount = 100;
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
        
        _testClients = Enumerable.Range(0, TestClientsCount)
            .Select(i=> new Client()
            {
                Name = $"Тестовый клиент #{i}",
                Manager = rnd.NextItem(managers),
                Products = GenereteClientsProductsTest(),
                Status = rnd.NextItem(clientTypes)
            }).ToArray();
        
        await _db.Clients.AddRangeAsync(_testClients);
        await _db.SaveChangesAsync();

        _logger.LogInformation("Инициализация клиентов выполнена за {0} мс", loggerTimer.Elapsed.TotalMilliseconds);
    }

    /// <summary>
    /// Генеарация тестовых значений продуктов для клиентов
    /// </summary>
    /// <returns></returns>
    private Product[] GenereteClientsProductsTest()
    {
        Random rnd = new Random();
        
        var products = new Product[rnd.Next(0, 10)];

        for (int i = 0; i < products.Length; i++)
        {
            products[i] = rnd.NextItem(_testProducts);
        }

        return products;
    }
}