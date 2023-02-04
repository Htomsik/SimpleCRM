using SimpleSRM.Models.Entities.Base;

namespace SimpleSRM.Models.Services;

/// <summary>
///     Сервис работающий  с коллекциями
/// </summary>
/// <typeparam name="T">Любой Entity тип</typeparam>
public static class EntityCollectionServices
{
    /// <summary>
    ///     Проверка на соривеисвме коллекций по id элементов в них
    /// </summary>
    /// <param name="mainCollection">Первая коллекция</param>
    /// <param name="subCollection">Вторая коллекция</param>
    /// <typeparam name="TEntity">тип элементов в коллекции (любый Entity)</typeparam>
    /// <returns>True - если коллекции идентичны</returns>
    public static bool IsCollectionsEqualsNoDeep<TEntity>(ICollection<TEntity> mainCollection,
        ICollection<TEntity> subCollection) where TEntity : IEntity
    {
        if (mainCollection.Count != subCollection.Count) return false;

        if (mainCollection.Count == 0 && subCollection.Count == 0) return true;

        return mainCollection.Count(item => subCollection.All(subItem => subItem.Id != item.Id)) == 0;
    }

    /// <summary>
    ///     Проверка на дубликаты Entity в коллекции по id
    /// </summary>
    /// <param name="collection">Коллекция по которой проихводится поиск с</param>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns>True - если есть дубликаты</returns>
    public static bool IsCollectionHaveDuplicateByIds<TEntity>(IEnumerable<TEntity> collection) where TEntity : IEntity
        =>
        collection.GroupBy(x => x.Id)
        .SelectMany(g => g.Skip(1)).Count() != 0;
    

    /// <summary>
    ///     Поиск по Entity коллекции
    /// </summary>
    /// <param name="scanCollection">Ссылка на коллекцию</param>
    /// <param name="id">id по которому поизводится поиск в коллекции</param>
    /// <returns>TEntity если найдено, Default для TEntity если не найдено</returns>
    public static TEntity? FindElemByIdInCollection<TEntity>(IEnumerable<TEntity> scanCollection, int id)
        where TEntity : IEntity
    {
        return scanCollection.FirstOrDefault(elem => elem.Id == id);
    }
    
}