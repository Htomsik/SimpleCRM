using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Base;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTaskDalTests.Resources;

internal static class GlobalResources
{
    #region Initializer : тестовые Entity данные

    private static EntitiesTestDataInitializer? _initializer;

    public static EntitiesTestDataInitializer Initializer => _initializer ??= new EntitiesTestDataInitializer();

    #endregion

    #region GetRandomEntity : Получение рандоного NamedEntity по типу

    private static readonly Random Rnd = new();

    /// <summary>
    ///     Получение рандоного NamedEntity по типу
    /// </summary>
    /// <typeparam name="TEntity">Тип, по которому требуется получить NamedEntity</typeparam>
    /// <returns></returns>
    public static TEntity GetRandomEntity<TEntity>() where TEntity : INamedEntity, new()
        => (TEntity)RandomEntityByType[typeof(TEntity)];


    /// <summary>
    ///     Словарь сопоставления типов с рандомными Entity (для удобства работы с днными в тестах)
    /// </summary>
    private static readonly Dictionary<Type, INamedEntity> RandomEntityByType = new()
    {
        { typeof(Client), Initializer.TestClients[Rnd.Next(0, Initializer.TestClients.Length)] },
        { typeof(Manager), Initializer.TestManagers[Rnd.Next(0, Initializer.TestManagers.Length)] },
        { typeof(Product), Initializer.TestProducts[Rnd.Next(0, Initializer.TestProducts.Length)] },
        { typeof(ClientStatus), Initializer.ClientTypes[Rnd.Next(0, Initializer.ClientTypes.Length)] },
        { typeof(ProductType), Initializer.ProductTypes[Rnd.Next(0, Initializer.ProductTypes.Length)] }
    };

    #endregion
}