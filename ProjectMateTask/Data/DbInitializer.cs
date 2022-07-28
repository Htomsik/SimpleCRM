using System;
using System.Collections.Generic;
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
    public async Task InitializeAsync()
    {
        //В случае если нету базы создает ее и накатывает миграции
        await _db.Database.MigrateAsync().ConfigureAwait(false);
        
        if(await  _db.ClientTypes.AnyAsync()) return;
    }

    private const int ClientTypesCount = 2;
    private ClientStatus[] _clientTypes;
    
    /// <summary>
    /// Инициализация типов клиентов
    /// </summary>
    private async Task InitializeClientTypes()
    {
        _clientTypes = new ClientStatus[ClientTypesCount]
        {
            new ClientStatus{Name = "Ключевой"},
            new ClientStatus{Name = "Обычный"}
        };

       await _db.ClientTypes.AddRangeAsync(_clientTypes);
       await _db.SaveChangesAsync();
    }
    
    private const int ProductTypeCount = 4;
    private ProductType[] _productTypes ;
    
    /// <summary>
    /// Инициализация типов продукта
    /// </summary>
    private async Task InitializeProductType()
    {
        _productTypes = new ProductType[ProductTypeCount]
        {
            new ProductType{Name = "Постоянная лицензия"},
            new ProductType{Name = "Месячная подписка"},
            new ProductType{Name = "Квартальная подписка"},
            new ProductType{Name = "Годовая подписка"}
        };

        await _db.ProductTypes.AddRangeAsync(_productTypes);
        await _db.SaveChangesAsync();
    }

    private const int TestProductsCount = 100;
    private Product[] _testProducts;
    /// <summary>
    /// Иницилизация тестовых значений продуктов в бд
    /// </summary>
    private async Task InitializeTestProduct()
    {
        Random rnd = new Random();
        
        _testProducts = Enumerable.Range(0, TestProductsCount)
            .Select(i=> new Product
            {
                Name = $"Тестовый продукт #{i}",
                Type = rnd.NextItem(_productTypes)
                
            }).ToArray();

        await _db.Products.AddRangeAsync(_testProducts);
        await _db.SaveChangesAsync();
    }
    
    
    private const int TestManagersCount = 100;
    private Manager[] _testManagers;
    /// <summary>
    /// Иницилизация тестовых значений продуктов в бд
    /// </summary>
    private async Task InitializeTestManagers()
    {
        _testManagers = Enumerable.Range(0, TestManagersCount)
            .Select(i=> new Manager()
            {
                Name = $"Тестовый менеджер #{i}",
            }).ToArray();
        
        await _db.Managers.AddRangeAsync(_testManagers);
        await _db.SaveChangesAsync();
    }
    
    private const int TestClientsCount = 100;
    private Client[] _testClients;
    /// <summary>
    /// Иницилизация тестовых значений клиентов в бд
    /// </summary>
    private async Task InitializeTestClients()
    {
        Random rnd = new Random();
        _testClients = Enumerable.Range(0, TestClientsCount)
            .Select(i=> new Client()
            {
                Name = $"Тестовый клиент #{i}",
                Manager = rnd.NextItem(_testManagers),
                Products = GenereteClientsProductsTest()
            }).ToArray();
        
        await _db.Clients.AddRangeAsync(_testClients);
        await _db.SaveChangesAsync();

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