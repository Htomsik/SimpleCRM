using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Models.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;

namespace ProjectMateTask.VMD.AppInfrastructure;

/// <summary>
///     Vmd для главного меню
/// </summary>
internal sealed class MainMenuVmd : BaseVmd
{
    /// <summary>
    ///     Vmd для главного меню
    /// </summary>
    /// <param name="typeMainEntityNavigationServices">Сервис навигации по MainEntityVmd типам</param>
    public MainMenuVmd(ITypeNavigationServices typeMainEntityNavigationServices)
    {
        #region Инициализация команд

        MenuNavigationCommand = new TypeNavigationCmd(typeMainEntityNavigationServices);

        #endregion

        #region Инициализация свойств

        MenuItems = new ObservableCollection<MenuItemWithCommand>
        {
            new("Менеджеры", PackIconKind.AccountTie, MenuNavigationCommand, typeof(MainManagerVmd)),
            new("Клиенты", PackIconKind.Account, MenuNavigationCommand, typeof(MainClientVmd)),
            new("Продукты", PackIconKind.Shopping, MenuNavigationCommand, typeof(MainProductVmd)),
            new("Статусы клиентов", PackIconKind.Administrator, MenuNavigationCommand, typeof(MainClientStatusVmd)),
            new("Типы продуктов", PackIconKind.FileDocument, MenuNavigationCommand, typeof(MainProductTypeVmd))
        };

        #endregion
    }

    #region Поля и  свойства

    /// <summary>
    ///     Коллекцию навигационного меню для MainEntityVmd страниц
    /// </summary>
    public ObservableCollection<MenuItemWithCommand> MenuItems { get; }

    #endregion

    #region Команды

    /// <summary>
    ///     Команда навигации между страницами
    /// </summary>
    public ICommand MenuNavigationCommand { get; }

    #endregion
}