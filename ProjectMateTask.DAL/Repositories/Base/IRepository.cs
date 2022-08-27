using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Repositories;

/// <summary>
///     Репозитоий работы с Entity
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : IEntity
{
    /// <summary>
    ///     Коллекция всех частично отслеживаемых сущностей
    /// </summary>
    IQueryable<T> PartTrackingItems { get; }
    
    /// <summary>
    ///     Коллекция всех частично отслеживаемых сущностей
    /// </summary>
    IQueryable<T> FullTrackingItems { get; }

    /// <summary>
    ///     Получение сущности по id c частичным отслеживанием (Коллекции не отслеживаются)
    /// </summary>
    /// <param name="id">id сущности</param>
    /// <returns></returns>
    T GetAsPartTracking(int id);

    /// <summary>
    ///     Асинхронное получение сущности по id c частичным отслеживанием (Коллекции не отслеживаются)
    /// </summary>
    /// <param name="id">id сущности</param>
    /// <param name="cancelToken">Токен отмены</param>
    /// <returns></returns>
    Task<T> GetAsPartTrackingAsync(int id, CancellationToken cancelToken = default);

    /// <summary>
    ///  Получение сущности по id c полным отслеживанием
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    T GetAsFullTracking(int id);

    // <summary>
    ///  Асинхронное получение сущности по id c полным отслеживанием
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancelToken">Токен отмены</param>
    /// <returns></returns>
    T GetAsFullTrackingAsync(int id, CancellationToken cancelToken = default);

    /// <summary>
    ///     Добавление новой сущности, ее первичный ключ
    /// </summary>
    /// <param name="item">добавляемая сущность</param>
    /// <returns></returns>
    void Add(T item);

    /// <summary>
    ///     Асинхронное добавление новой сущности, ее первичный ключ
    /// </summary>
    /// <param name="item">добавляемая сущность</param>
    /// <param name="cancelToken">Токен отмены</param>
    /// <returns></returns>
    Task AddAsync(T item, CancellationToken cancelToken = default);

    /// <summary>
    ///     Добавление коллекции сущностей
    /// </summary>
    /// <param name="items">Коллекция сущностей</param>
    void AddCollection(IEnumerable<T> items);

    /// <summary>
    ///     Асинхронное добавление коллекции сущностей
    /// </summary>
    /// <param name="items">Коллекция сущностей</param>
    /// <param name="cancelToken">Токен отмены</param>
    /// <returns></returns>
    Task AddCollectionAsync(IEnumerable<T> items, CancellationToken cancelToken = default);

    /// <summary>
    ///     Обновление сущности
    /// </summary>
    /// <param name="item">Обновляемая сущность</param>
    void Update(T item);

    /// <summary>
    ///     Асинхронное обновление сущности
    /// </summary>
    /// <param name="item">Обновляемая сущность</param>
    /// <param name="cancelToken">Токен отмены</param>
    /// <returns></returns>
    Task UpdateAsync(T item, CancellationToken cancelToken = default);

    /// <summary>
    ///     Обновление коллекции сущностей
    /// </summary>
    /// <param name="items">Коллекция сущностей</param>
    void UpdateCollection(IEnumerable<T> items);

    /// <summary>
    ///     Асинхронное обновление сущностей
    /// </summary>
    /// <param name="items">Коллекция сущностей</param>
    /// <param name="cancelToken">Токен отмены</param>
    /// <returns></returns>
    Task UpdateCollectionAsync(IEnumerable<T> items, CancellationToken cancelToken = default);

    /// <summary>
    ///     Удаление сущности
    /// </summary>
    /// <param name="item">Обновляемая сущность</param>
    void Remove(T item);

    /// <summary>
    ///     Асинхронное удаление сущности
    /// </summary>
    /// <param name="item">удаляемая сущность</param>
    /// <param name="cancelToken">Токен отмены</param>
    /// <returns></returns>
    Task RemoveAsync(T item, CancellationToken cancelToken = default);

    /// <summary>
    ///     Удаление коллекции сущностей
    /// </summary>
    /// <param name="items">Коллекция сущностей</param>
    void RemoveCollection(IEnumerable<T> items);

    /// <summary>
    ///     Асинхронное удаление коллекции сущностей
    /// </summary>
    /// <param name="items">Коллекция сущностей</param>
    /// <param name="cancelToken">Токен отмены</param>
    Task RemoveCollectionAsync(IEnumerable<T> items, CancellationToken cancelToken = default);
}