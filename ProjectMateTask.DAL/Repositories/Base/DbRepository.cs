using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Repositories.Base;

internal class DbRepository<T> : IRepository<T> where T : Entity, new()
{
    private readonly ProjectMateTaskDb _db;

    private readonly DbSet<T> _set;

    public DbRepository(ProjectMateTaskDb db)
    {
        _db = db;
        _set = _db.Set<T>();
    }

    public virtual IQueryable<T> Items => _set;

    public T Get(int id)
    {
        return Items.SingleOrDefault(item => item.Id == id)!;
    }

    public async Task<T> GetAsync(int id, CancellationToken cancelToken = default)
    {
        return await Items.SingleOrDefaultAsync(item => item.Id == id, cancelToken).ConfigureAwait(true);
    }


    public void Add(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item) + " не должным будть пустым");
        _db.Entry(item).State = EntityState.Added;
        _db.SaveChanges();
    }

    public async Task AddAsync(T item, CancellationToken cancelToken = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item) + " не должным будть пустым");
        _db.Entry(item).State = EntityState.Added;
        await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
    }

    public void Update(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item) + " не должным будть пустым");
        _db.Entry(item).State = EntityState.Modified;
        _db.SaveChanges();
    }

    public async Task UpdateAsync(T item, CancellationToken cancelToken = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item) + " не должным будть пустым");
        _db.Entry(item).State = EntityState.Modified;
        await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
    }

    public void Remove(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item) + " не должным будть пустым");
        _db.Remove(item);
        _db.SaveChanges();
    }

    public async Task RemoveAsync(T item, CancellationToken cancelToken = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item) + " не должным будть пустым");
        _db.Remove(item);
         await _db.SaveChangesAsync(cancelToken).ConfigureAwait(false);
    }
}