using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Repositories;

public interface IRepository<T> where T : class, IEntity, new()
{
    /// <summary>
    ///     Коллекция всех сущностей
    /// </summary>
    IQueryable<T> Items { get; }

    /// <summary>
    ///     Получение сущности по id
    /// </summary>
    /// <param name="id">id сущности</param>
    /// <returns></returns>
    T Get(int id);

    /// <summary>
    ///     Асинхронное получение сущности по id
    /// </summary>
    /// <param name="id">id сущности</param>
    /// <param name="cancelToken">Токен отмены</param>
    /// <returns></returns>
    Task<T> GetAsync(int id, CancellationToken cancelToken = default);

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
}