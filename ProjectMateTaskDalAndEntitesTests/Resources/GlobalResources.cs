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

    static Random rnd = new Random();
    
    /// <summary>
    ///     Получение рандоного NamedEntity по типу
    /// </summary>
    /// <typeparam name="TEntity">Тип, по которому требуется получить NamedEntity</typeparam>
    /// <returns></returns>
    public static TEntity GetRandomEntity<TEntity>() where TEntity : INamedEntity, new() =>
        (TEntity)RandomEntityByType[typeof(TEntity)];
   
    
    private static Dictionary<Type,INamedEntity> RandomEntityByType = new()
    {
        {typeof(Client),Initializer.TestClients[rnd.Next(0, Initializer.TestClients.Length)]},
        {typeof(Manager),Initializer.TestManagers[rnd.Next(0, Initializer.TestManagers.Length)]},
        {typeof(Product),Initializer.TestProducts[rnd.Next(0, Initializer.TestProducts.Length)]},
        {typeof(ClientStatus),Initializer.ClientTypes[rnd.Next(0, Initializer.ClientTypes.Length)]},
        {typeof(ProductType),Initializer.ProductTypes[rnd.Next(0, Initializer.ProductTypes.Length)]}
    };

    #endregion
    
}