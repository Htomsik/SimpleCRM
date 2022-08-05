using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Repositories;

internal abstract class DbRepository<T> : IRepository<T> where T : Entity, new()
{
    protected readonly ProjectMateTaskDb _db;

    protected readonly DbSet<T> _set;

    public DbRepository(ProjectMateTaskDb db)
    {
        _db = db;
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
        if(!NullChecker(item)) return;
        _db.Entry(item).State = EntityState.Added;
        _db.SaveChanges();
    }

    public async Task AddAsync(T item, CancellationToken cancelToken = default)
    {
        if(!NullChecker(item)) return;
        _db.Entry(item).State = EntityState.Added;
        await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
    }

    public void AddCollection(IEnumerable<T> items)
    {
        if (!CollectionNullChecker(items)) return;
        _db.AddRange(items);
        _db.SaveChanges();
    }

    public async Task AddCollectionAsync(IEnumerable<T> items, CancellationToken cancelToken = default)
    {
        if (!CollectionNullChecker(items)) return;
        await _db.AddRangeAsync(items, cancelToken);
        await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
    }

    public void Update(T item)
    {
        if(!NullChecker(item)) return;
        _db.Entry(item).State = EntityState.Modified;
        _db.SaveChanges();
    }
    
    public async Task UpdateAsync(T item, CancellationToken cancelToken = default)
    {
        if(!NullChecker(item)) return;
        _db.Entry(item).State = EntityState.Modified;
        await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
    }

    
    public void UpdateCollection(IEnumerable<T> items)
    {
        if (!CollectionNullChecker(items)) return;
        _db.UpdateRange(items);
        _db.SaveChanges();
    }

    public async Task UpdateCollectionAsync(IEnumerable<T> items, CancellationToken cancelToken = default)
    {
        if (!CollectionNullChecker(items)) return;
        _db.UpdateRange(items);
        await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
    }


    public void Remove(T item)
    {
        if(!NullChecker(item)) return;
        _db.Entry(item).State = EntityState.Deleted;
        _db.SaveChanges();
    }

    public async Task RemoveAsync(T item, CancellationToken cancelToken = default)
    {
        if(!NullChecker(item)) return;
        _db.Entry(item).State = EntityState.Deleted;
         await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
    }
    
    public void RemoveCollection(IEnumerable<T> items)
    {
        if (!CollectionNullChecker(items)) return;
        _db.RemoveRange(items);
        _db.SaveChanges();

    }

    public async Task RemoveCollectionAsync(IEnumerable<T> items, CancellationToken cancelToken = default)
    {
        if (!CollectionNullChecker(items)) return;
        _db.RemoveRange(items);
        await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
    }

    protected bool NullChecker(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item) + " не должным будть пустым");
        return true;
    }

    protected bool CollectionNullChecker(IEnumerable<T> items)
    {
        if (items is null || items.All(item=>item is null)) throw new ArgumentNullException(nameof(items) + " не должным будть пустым");
        return true;
    }
}