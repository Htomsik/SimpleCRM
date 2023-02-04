using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SimpleSRM.WPF.Data;
using SimpleSRM.WPF.Infrastructure.CMD.AppInfrastructure;
using SimpleSRM.WPF.VMD.Base;

namespace SimpleSRM.WPF.VMD.Pages;

/// <summary>
///     Стартовая страница приложения
/// </summary>
internal sealed class HomeVmd : BaseVmd
{
    #region Поля и свойства

    private readonly IDbInitializer _dbInitializer;

    public override string Tittle => "Домашняя страница";

    #endregion
    
    /// <summary>
    /// Стартовая страница приложения
    /// </summary>
    /// <param name="dbInitializer">Инициализатор бд</param>
    public HomeVmd(IDbInitializer dbInitializer)
    {
        _dbInitializer = dbInitializer;

        RebuildDbOnWorkingModeCommand = new UserDialogAsyncCmd(OnRebuildDB,"Все текущие данные в базе очистится и произойдет начальная подготовка для полноценной работы с приложением. Выполнение данной команды требует ручного перезапуска приложения. Хотите продолжить?");

        RebuildDbOnTestModeCommand = new UserDialogAsyncCmd(OnTestDataInitialize,"Все текущие данные в базе очистится и произойдет начальная подготовка для работы с приложением вместе с заполнением демонстрационными данными. Выполнение данной команды требует ручного перезапуска приложения. Хотите продолжить?");

        #region Инициализция команд

        OpenHtomsikGithubCommnad = new OpenBrowserLinkCmd("https://github.com/Htomsik");

        OpenProjectGithubCommnad = new OpenBrowserLinkCmd("https://github.com/Htomsik/SimpleSRM.WPF");

        OpenProjectAssetsCommand =
            new OpenBrowserLinkCmd("https://github.com/Htomsik/SimpleSRM.WPF/tree/master/Assets");
        
        #endregion

    }
    
    #region Команды

    #region Команды-ссылки

    /// <summary>
    ///     Команда открытия ссылки на создателя
    /// </summary>
    public ICommand OpenHtomsikGithubCommnad { get; }
    
    /// <summary>
    ///     Команда открытия ссылки на проект
    /// </summary>
    public ICommand OpenProjectGithubCommnad { get; }
    
    /// <summary>
    ///     Команда открытия ссылки на ресурсы проекта
    /// </summary>
    public ICommand OpenProjectAssetsCommand { get; }

    #endregion
    
    #region RebuildDbOnWorkingModeCommand : Команда пересборки базы данных

    /// <summary>
    ///     Команда пересборки бд
    /// </summary>
    public ICommand RebuildDbOnWorkingModeCommand { get; }

    private async Task OnRebuildDB()
    {
        await _dbInitializer.RebuildDataBaseAsync();

        Task.WaitAll();
            
        Application.Current.Shutdown();

    }

    #endregion

    #region RebuildDbOnTestModeCommand : Команда заполнения базы данных тестовыми данными

    /// <summary>
    ///     Команда инициализации бд
    /// </summary>
    public ICommand RebuildDbOnTestModeCommand { get; }

    private async Task OnTestDataInitialize()
    {
        await _dbInitializer.RebuildDataBaseAsync();
        
        await _dbInitializer.InitializeTestDataAsync();
        
        Task.WaitAll();
        
        Application.Current.Shutdown();
    }
    
 
    #endregion

    #endregion
    
}