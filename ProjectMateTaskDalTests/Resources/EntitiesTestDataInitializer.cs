using System;
using System.Linq;
using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Types;
using ProjetMateTaskEntities.Stores;

namespace ProjectMateTaskDalTests.Resources;

internal class EntitiesTestDataInitializer
{
    public const int TestClientTypesCount = 2;
    public ClientStatus[] ClientTypes;
    
    public const int TestProductTypesCount = 4;
    public ProductType[] ProductTypes;
    
    public const int TestProductsCount = 20;
    public Product[] TestProducts;
    
    public const int TestManagersCount = 20;
    public Manager[] TestManagers;
    
    public const int TestClientsCount = 20;
    public Client[] TestClients;

    private Random _rnd;
    
    public EntitiesTestDataInitializer()
    {
       
        _rnd = new Random();
        
        InitializeTestClientTypes();
        InitializeTestProductTypes();
        InitializeTestManagers();
        InitializeTestProducts();
        InitializeTestClients();
    }

    #region InitializeTestClientTypes : Инициализация типов клиентов

    private  void InitializeTestClientTypes()
    {
        ClientTypes = new ClientStatus[TestClientTypesCount]
        {
            new ClientStatus(0,"Ключевой"),
            new ClientStatus(1, "Обычный")
        };
        
    }

    #endregion

    #region InitializeTestProductTypes : Инициализация типов продуктов

    private void  InitializeTestProductTypes()
    {
        ProductTypes = new ProductType[TestProductTypesCount]
        {
            new ProductType{Id = 0,Name = "Постоянная лицензия"},
            new ProductType{Id = 1,Name="Месячная подписка"},
            new ProductType{Id = 2,Name = "Квартальная подписка"},
            new ProductType{Id = 3,Name = "Годовая подписка"}
        };
    }

    #endregion

    #region InitializeTestProducts : Инициализация тестовых продуктов

    private  void InitializeTestProducts()
    {
        
        
        TestProducts = Enumerable.Range(0, TestManagersCount)
            .Select(i=> new Product()
            {
                Id = i,
                Name = $"Тестовый продукт #{i}",
                Type = ProductTypes[_rnd.Next(0,TestProductTypesCount)]
            }).ToArray();
    }

    #endregion

    #region InitializeTestManagers : Инициализация тестовых менеджеров

    private  void InitializeTestManagers()
    {
        TestManagers = Enumerable.Range(0, TestManagersCount)
            .Select(i=> new Manager()
            {
                Id = i,
                Name = $"Тестовый менеджер #{i}",
            }).ToArray();
    }

    #endregion

    #region InitializeTestClients : Инициализация тестовых клиентов

    private  void InitializeTestClients()
    {
        TestClients = Enumerable.Range(0, TestClientsCount)
            .Select(i=> new Client()
            {
                Id = i,
                Name = $"Тестовый клиент #{i}",
                Manager = TestManagers[_rnd.Next(0,TestManagersCount)],
                Products = new EntityCollectionStore<Product>(RandomClientsProductsTest()),
                Status = ClientTypes[_rnd.Next(0,TestClientTypesCount)]
            }).ToArray();
        
    }

    #endregion
    
    #region RandomClientsProductsTest : Генератор рандомных массивов клиентов

   
    private Product[] RandomClientsProductsTest()
    {
        Random rnd = new Random();
        
        var products = new Product[rnd.Next(0, 10)];

        for (int i = 0; i < products.Length; i++)
        {
            products[i] = TestProducts[rnd.Next(0,TestProductsCount)];
        }

        return products;
    }

    #endregion
    
   
}