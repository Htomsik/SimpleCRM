using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjectMateTask.Data;
using ProjectMateTask.Infrastructure.CMD;
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