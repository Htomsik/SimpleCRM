﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleSRM.DAL.Context;
using SimpleSRM.Models.Entities.Base;

namespace SimpleSRM.DAL.Repositories.Base;

/// <summary>
///     Репозиторий работы с Entity через бд
/// </summary>
/// <typeparam name="T">Любой NamedEntity тип</typeparam>
internal abstract class DbRepository<T> : IRepository<T> where T : NamedEntity, new()
{
    protected readonly DataDb _db;
    
    private readonly ILogger<DbRepository<T>> _logger;
    
    protected readonly DbSet<T> _set;

    public DbRepository(DataDb db, ILogger<DbRepository<T>> logger)
    {
        _db = db;
        _logger = logger;
        _set = _db.Set<T>();
    }

    public IQueryable<T> PartTrackingItems => FullTrackingItems.AsNoTrackingWithIdentityResolution();
    
    public virtual IQueryable<T> FullTrackingItems => _set;

    public virtual T GetAsPartTracking(int id)
    {
        return PartTrackingItems.FirstOrDefault(item => item.Id == id)!;
    }
    
    public async Task<T> GetAsPartTrackingAsync(int id, CancellationToken cancelToken = default)
    {
        return (await PartTrackingItems.FirstOrDefaultAsync(item => item.Id == id, cancelToken).ConfigureAwait(true))!;
    }

    public virtual T GetAsFullTracking(int id)
    {
        return FullTrackingItems.FirstOrDefault(item => item.Id == id)!;
    }


    public virtual T GetAsFullTrackingAsync(int id, CancellationToken cancelToken = default)
    {
        return FullTrackingItems.FirstOrDefault(item => item.Id == id)!;
    }
   


    public void Add(T item)
    {
        _logger.LogInformation($"Добавление {item.Name} в бд...");
        
        try
        {
            if(!NullChecker(item)) return;
            _db.Entry(item).State = EntityState.Added;
            _db.SaveChanges();
            
            _logger.LogInformation($"Добавление {item.Name} в бд прошло успешно");
        }
        catch (Exception e)
        {
          _logger.LogError(e,$"Ошибка добавления {item.Name} в бд");
        }
        
    }

    public async Task AddAsync(T item, CancellationToken cancelToken = default)
    {
        
        _logger.LogInformation($"Асинхронное добавление {item.Name} в бд...");

        try
        {
            if(!NullChecker(item)) return;
            _db.Entry(item).State = EntityState.Added;
            await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
            
            _logger.LogInformation($"Асинхронное добавление {item.Name} в бд успешно");
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Ошибка асинхронного добавления {item.Name} в бд");
        }
    
      
    }

    public void AddCollection(IEnumerable<T> items)
    {

        _logger.LogInformation($"Добавление коллекции в бд...");
        
        try
        {
            if (!CollectionNullChecker(items)) return;
            _db.AddRange(items);
            _db.SaveChanges();
            
            _logger.LogInformation($"Добавление коллекции в бд прошло успешно");
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Ошибка добавления коллекции в бд");
        }
        
    }

    public async Task AddCollectionAsync(IEnumerable<T> items, CancellationToken cancelToken = default)
    {
        
        _logger.LogInformation($"Добавление коллекции в бд...");
        
        try
        {
            if (!CollectionNullChecker(items)) return;
            await _db.AddRangeAsync(items, cancelToken);
            await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
            
            _logger.LogInformation($"Асинхронное добавление коллекции в бд прошло успешно");
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Ошибка асинхронного добавления коллекции в бд");
        }
    }

    public void Update(T item)
    {
        
        _logger.LogInformation($"Обновление {item.Name} в бд...");
        
        try
        {
            if(!NullChecker(item)) return;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            
            _logger.LogInformation($"Обновление {item.Name} в бд прошло успешно");
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Ошибка обновление {item.Name} в бд");
        }
        
        
    }
    
    public async Task UpdateAsync(T item, CancellationToken cancelToken = default)
    {

        _logger.LogInformation($"Асинхронное обновление {item.Name} в бд...");
        
        try
        {
            if(!NullChecker(item)) return;
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
            
            _logger.LogInformation($"Асинхронное обновление {item.Name} в бд прошло успешно");
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Ошибка асинхронного обновление {item.Name} в бд");
        }
    }

    
    public void UpdateCollection(IEnumerable<T> items)
    {
        
        _logger.LogInformation($"Обновление коллекции c {items.GetType().GenericTypeArguments} в бд...");
        
        try
        {
            if (!CollectionNullChecker(items)) return;
            _db.UpdateRange(items);
            _db.SaveChanges();
            
            _logger.LogInformation($"Обновление коллекции c {items.GetType().GenericTypeArguments} в бд прошло успешно");
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Ошибка обновления коллекции c {items.GetType().GenericTypeArguments} в бд");
        }
    }

    public async Task UpdateCollectionAsync(IEnumerable<T> items, CancellationToken cancelToken = default)
    {
        
        _logger.LogInformation($"Асинхронное обновление коллекции c {items.GetType().GenericTypeArguments} в бд...");
        
        try
        {
            if (!CollectionNullChecker(items)) return;
            _db.UpdateRange(items);
            await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
            
            _logger.LogInformation($"Асинхронное обновление коллекции c {items.GetType().GenericTypeArguments} в бд прошло успешно");
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Ошибка асинхронного обновления коллекции c {items.GetType().GenericTypeArguments} в бд");
        }
        
        
 
    }


    public void Remove(T item)
    {
        
        _logger.LogInformation($"Удаление {item.Name} в бд...");
        
        try
        {
            if(!NullChecker(item)) return;
            _db.Entry(item).State = EntityState.Deleted;
            _db.SaveChanges();
            
            _logger.LogInformation($"Удаление {item.Name} в бд прошло успешно");
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Ошибка удаления {item.Name} в бд");
        }
    }

    public async Task RemoveAsync(T item, CancellationToken cancelToken = default)
    {
        
         _logger.LogInformation($"Асинхронное удаление {item.Name} в бд...");
        
         try
         {
             if(!NullChecker(item)) return;
             _db.Entry(item).State = EntityState.Deleted;
             await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
            
             _logger.LogInformation($"Асинхронное удаление {item.Name} в бд прошло успешно");
         }
         catch (Exception e)
         {
             _logger.LogError(e,$"Ошибка асинхонного удаления {item.Name} в бд");
         }
    }
    
    public void RemoveCollection(IEnumerable<T> items)
    {
        
        _logger.LogInformation($"Удаление коллекции c {items.GetType().GenericTypeArguments} в бд...");
        
        try
        {
            if (!CollectionNullChecker(items)) return;
            _db.RemoveRange(items);
            _db.SaveChanges();
            
            _logger.LogInformation($"Удаление коллекции c {items.GetType().GenericTypeArguments} в бд прошло успешно");
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Ошибка удаления c {items.GetType().GenericTypeArguments} данных в бд");
        }

    }

    public async Task RemoveCollectionAsync(IEnumerable<T> items, CancellationToken cancelToken = default)
    {
        
        _logger.LogInformation($"Асинхронное удаление c {items.GetType().GenericTypeArguments} данных в бд...");
        
        try
        {
            if (!CollectionNullChecker(items)) return;
            _db.RemoveRange(items);
            await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
            
            _logger.LogInformation($"Асинхронное удаление c {items.GetType().GenericTypeArguments} данных в бд прошло успешно");
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Ошибка асинхронного удаления c {items.GetType().GenericTypeArguments} данных в бд");
        }
    }

    /// <summary>
    ///     Метод проверки значения на null
    /// </summary>
    /// <param name="item">Проверяемое значение</param>
    /// <exception cref="ArgumentNullException">Возникает если знаачеине null</exception>
    protected bool NullChecker(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item) + " не должным будть пустым");
        return true;
    }

    /// <summary>
    ///     Метод проверки коллекции на null
    /// </summary>
    /// <param name="items">Проверяемая коллекция</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Возникает если коллекция или любое значение в коллекции null</exception>
    protected bool CollectionNullChecker(IEnumerable<T> items)
    {
        if (items is null || items.All(item=>item is null)) throw new ArgumentNullException(nameof(items) + " не должным будть пустым");
        return true;
    }
}