using System.Threading.Tasks;
using System.Windows.Input;
using ProjectMateTask.Data;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages;

internal sealed class MainPageVmd:BaseNotGenericEntityVmd
{
    /// <summary>
    /// Сервис Инициализации бд
    /// </summary>
    private readonly IDbInitializer _dbInitializer;

    public MainPageVmd(IDbInitializer dbInitializer)
    {
        _dbInitializer = dbInitializer;

        RebuildDbCommand = new AsyncLambdaCmd(OnRebuildDB);

        TestDataInitializeCommand = new AsyncLambdaCmd(OnTestDataInitialize);
    }


    #region RebuildDBCommand : Команда пересборки базы данных

    public ICommand RebuildDbCommand { get; }

    private async Task OnRebuildDB()
    {
        await _dbInitializer.RebuildDataBaseAsync();
    }

    #endregion

    #region TestDataInitializeCommand : Команда заполнения базы данных тестовыми данными

    public ICommand TestDataInitializeCommand { get; }

    private async Task OnTestDataInitialize()
    {
        await _dbInitializer.InitializeTestDataAsync();
    }

    #endregion
  
}