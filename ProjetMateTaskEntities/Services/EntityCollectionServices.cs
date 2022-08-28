using ProjetMateTaskEntities.Entities.Base;

namespace ProjetMateTaskEntities.Services;

/// <summary>
///     Сервис работающий  с коллекциями
/// </summary>
/// <typeparam name="T">Любой Entity тип</typeparam>
public static class EntityCollectionServices
{
    public static bool IsCollectionsEqualsNoDeep<TEntity>(ICollection<TEntity> mainCollection,
        ICollection<TEntity> subCollection) where TEntity : IEntity
    {
        if (mainCollection.Count != subCollection.Count) return false;

        if (mainCollection.Count == 0 && subCollection.Count == 0) return true;

        return mainCollection.Count(item => subCollection.All(subItem => subItem.Id != item.Id)) == 0;
    }

    /// <summary>
    ///     Поиск по Entity коллекции
    /// </summary>
    /// <param name="scanCollection">Ссылка на коллекцию</param>
    /// <param name="id">id по которому поизводится поиск в коллекции</param>
    /// <returns></returns>
    public static TEntity? FindElemByIdInCollection<TEntity>(ref IEnumerable<TEntity> scanCollection, int id)
        where TEntity : IEntity
    {
        return scanCollection.FirstOrDefault(elem => elem.Id == id);
    }
}