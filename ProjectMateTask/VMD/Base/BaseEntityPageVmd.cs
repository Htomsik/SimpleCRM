using System.Collections.ObjectModel;
using System.Linq;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;

namespace ProjectMateTask.VMD.Base;

internal abstract class BaseEntityPageVmd<TEntity>:BaseVmd where TEntity:class,IEntity,new()
{
    private readonly IRepository<TEntity> _entities;

    public  ObservableCollection<TEntity> Entities => new ObservableCollection<TEntity>( _entities.Items.ToArray());

    public BaseEntityPageVmd(IRepository<TEntity> entities)
    {
        _entities = entities;
    }

}