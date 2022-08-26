using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

internal class BaseSubEntityVmd<TEntity> : BaseEntityRepositoryVmd<TEntity>,ISubEntityVmd where TEntity: INamedEntity,new()
{
    public BaseSubEntityVmd(
        IRepository<TEntity> entitiesRepository, ICloseNavigationServices closeTypeNavigationService) : base(entitiesRepository)
    {
        #region Команды

            AddEntityToMainCommand = new LambdaCmd(OnAddEntity);

            CloseSubEntityPageCommand = new CloseNavigationCmd(closeTypeNavigationService);
            
        #endregion
    }

    public ICommand CloseSubEntityPageCommand { get; }
    
    #region AddEntityToMainCommand : Добавление выбранной сущности к родителю

    public ICommand AddEntityToMainCommand { get; }

    private void OnAddEntity(object p)
    {
        TEntity foundInRepository = EntitiesRepository.GetAsFullTracking(((TEntity)p).Id);
        
        AddEntityNotifier?.Invoke(foundInRepository);
    }

    #endregion

    public event Action<INamedEntity>? AddEntityNotifier;
    
    
}