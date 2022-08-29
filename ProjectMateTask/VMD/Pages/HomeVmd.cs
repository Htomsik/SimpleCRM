using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProjectMateTask.Data;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages;

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

        RebuildDbCommand = new UserDialogAsyncCmd(OnRebuildDB,"Выполнение данной команды требует ручного перезапуска приложения. Хотите продолжить?");

        TestDataInitializeCommand = new UserDialogAsyncCmd(OnTestDataInitialize,"Выполнение данной команды требует ручного перезапуска приложения. Хотите продолжить?");

        #region Инициализция команд

        OpenHtomsikGithubCommnad = new OpenBrowserLinkCmd("https://github.com/Htomsik");

        OpenProjectGithubCommnad = new OpenBrowserLinkCmd("https://github.com/Htomsik/ProjectMateTask");

        OpenProjectAssetsCommand =
            new OpenBrowserLinkCmd("https://github.com/Htomsik/ProjectMateTask/tree/master/Assets");
        
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
    
    #region RebuildDBCommand : Команда пересборки базы данных

    /// <summary>
    ///     Команда пересборки бд
    /// </summary>
    public ICommand RebuildDbCommand { get; }

    private async Task OnRebuildDB()
    {
        await _dbInitializer.RebuildDataBaseAsync();

        Task.WaitAll();
        
        //Application.Current.Shutdown();

    }

    #endregion

    #region TestDataInitializeCommand : Команда заполнения базы данных тестовыми данными

    /// <summary>
    ///     Команда инициализации бд
    /// </summary>
    public ICommand TestDataInitializeCommand { get; }

    private async Task OnTestDataInitialize()
    {
        await _dbInitializer.InitializeTestDataAsync();
        
        Task.WaitAll();
        
       // Application.Current.Shutdown();
    }
    
 
    #endregion

    #endregion
    
}