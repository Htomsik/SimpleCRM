using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.Entities.Base;

/// <summary>
///     Базовый класс для Entity
/// </summary>
internal abstract class BaseEntityVmd: BaseVmd, IEntityVmd 
{
    #region EntitiesFilteredView : фильтрованный список Entity

    protected CollectionViewSource _entitiesViewSource;

    /// <summary>
    ///     Коллекция фильтрованных Entity
    /// </summary>
    public virtual ICollectionView? EntitiesFilteredView => _entitiesViewSource?.View;

    #endregion
    
    
    /// <summary>
    ///     Название vmd
    /// </summary>
    public virtual string Tittle => "Не переопределенная страница";
    
   
    

}