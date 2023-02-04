using System;
using System.Windows.Input;
using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Base;
using SimpleSRM.WPF.Infrastructure.CMD;
using SimpleSRM.WPF.Infrastructure.CMD.AppInfrastructure;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using SimpleSRM.WPF.VMD.Pages.Entities.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds.Base;

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