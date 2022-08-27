using System;
using System.Windows.Input;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

/// <summary>
///     Базовая реализация для SubEntity vmd типов
/// </summary>
/// <typeparam name="TEntity">Любой SubEntityVmd тип</typeparam>
internal class BaseSubEntityVmd<TEntity> : BaseEntityRepositoryVmd<TEntity>, ISubEntityVmd
    where TEntity : INamedEntity, new()
{
    /// <summary>
    ///     Базовая реализация для SubEntity vmd типов
    /// </summary>
    /// <param name="entitiesRepository">Entity репозиторий</param>
    /// <param name="closeTypeNavigationService">Навигационный сервис закрытия SubEntity vmd типов</param>
    public BaseSubEntityVmd(
        IRepository<TEntity> entitiesRepository, ICloseNavigationServices closeTypeNavigationService) : base(
        entitiesRepository)
    {
        #region Инициализация команд

        AddSubEntityToMainEntityCommand = new LambdaCmd(OnAddEntity);

        CloseSubEntityPageCommand = new CloseNavigationCmd(closeTypeNavigationService);

        #endregion
    }

    #region Свойства и поля

    public event Action<INamedEntity>? AddEntityNotifier;

    #endregion

    #region Команды

    public ICommand CloseSubEntityPageCommand { get; }

    #region AddSubEntityToMainEntityCommand : Добавление выбранной сущности к родителю

    public ICommand AddSubEntityToMainEntityCommand { get; }

    private void OnAddEntity(object p)
    {
        var foundInRepository = EntitiesRepository.GetAsFullTracking(((TEntity)p).Id);

        AddEntityNotifier?.Invoke(foundInRepository);
    }

    #endregion

    #endregion
}