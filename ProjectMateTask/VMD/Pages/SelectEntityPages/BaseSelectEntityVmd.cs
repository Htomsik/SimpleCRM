﻿using System;
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
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.SelectEntityPages;

internal class BaseSelectEntityVmd<TEntity> : BaseVmd,ISelectEntityVmd where TEntity: INamedEntity,new()
{
    private readonly IRepository<TEntity> _entitiesRepository;
    
    #region EntitiesFilteredView : фильтрованный список Entity

    private CollectionViewSource _entitiesViewSource;

    public ICollectionView? EntitiesFilteredView => _entitiesViewSource?.View;

    #endregion
    
    #region Entities : Оригинльный список Entity

    private ObservableCollection<TEntity> _entities;

    public ObservableCollection<TEntity> Entities
    {
        get => _entities;
        set
        {
            
            if (!Set(ref _entities, value)) return;
            
            _entitiesViewSource = new CollectionViewSource
            {
                Source = value,
                SortDescriptions =
                {
                    new SortDescription("Name", ListSortDirection.Ascending)
                }
            };

            _entitiesViewSource.Filter += OnEntityFilter;
            _entitiesViewSource.View.Refresh();

            OnPropertyChanged(nameof(EntitiesFilteredView));
        }
    }

    #endregion
    
    #region Filter : Фильтр списка Entity

    private string _filter;

    public string Filter
    {
        get => _filter;
        set
        {
            if (Set(ref _filter, value.ToLower()))
                _entitiesViewSource.View.Refresh();
        }
    }

    private void OnEntityFilter(object sender, FilterEventArgs e)
    {
        if (!(e.Item is NamedEntity entity) || string.IsNullOrEmpty(Filter)) return;

        if (!entity.Name.ToLower().Contains(Filter)) e.Accepted = false;
    }

    #endregion

    #region InitializeRepositoryAsync : Инициализация репозитория

    private async Task InitializeRepositoryAsync()
    {
        Entities = new ObservableCollection<TEntity>(await _entitiesRepository.PartTrackingItems.ToArrayAsync());
    }
    #endregion

    public BaseSelectEntityVmd(
        IRepository<TEntity> entitiesRepository, ICloseNavigationServices closeNavigationServices)
    {
        _entitiesRepository = entitiesRepository;
        
        InitializeRepositoryAsync();

        #region Команды

            AddEntityCommand = new LambdaCmd(OnAddEntity);

            CloseSubEntityPageCommand = new CloseNavigationCmd(closeNavigationServices);
            
        #endregion

    }

    public ICommand CloseSubEntityPageCommand { get; }
    
    #region AddEntityCommand : Добавление новой сущности 

    public ICommand AddEntityCommand { get; }

    private void OnAddEntity(object p)
    {
        TEntity foundInRepository = _entitiesRepository.GetAsFullTracking(((TEntity)p).Id);
        
        AddEntityNotifier?.Invoke(foundInRepository);
    }

    #endregion

    public event Action<INamedEntity>? AddEntityNotifier;
    
    
}