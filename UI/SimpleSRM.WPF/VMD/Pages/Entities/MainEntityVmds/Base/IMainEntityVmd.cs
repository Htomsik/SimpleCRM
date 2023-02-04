using System.Windows.Input;
using SimpleSRM.WPF.VMD.Pages.Entities.Base;
using SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds.Base;

/// <summary>
///     Модель представления для MainEntity типов
/// </summary>
internal interface IMainEntityVmd : IEntityVmd
{
    #region Поля и свойства

    /// <summary>
    ///     Текущая связная сущность
    /// </summary>
    public ISubEntityVmd? CurrentSelectedSubEntityVmd { get; }
    
    /// <summary>
    ///     Флаг режима редактирования SelectedSubEntity
    /// </summary>
    public bool IsEditMode { get; set; }

    #endregion
    
    #region Команды

    /// <summary>
    ///     Команда принятия режимов (редактирование/добавление) Entity
    /// </summary>
    public ICommand AcceptModsCommand { get; set; }
    
    /// <summary>
    ///     Команда открытия режима редактирования Entity
    /// </summary>
    public ICommand OpenEditModeCommand { get; }
    
    /// <summary>
    ///     Команда открытия режим добавления нового Entity
    /// </summary>
    public ICommand OpenAddModeCommand { get; }
    
    /// <summary>
    ///     Команда закрытия режима редактирования/добавления Entity
    /// </summary>
    public ICommand CloseAllModsCommand { get; }
    
    /// <summary>
    ///     Команда добавления новой Entity (принятия режима добавления)
    /// </summary>
    public ICommand AcceptAddModeCommand { get; }
    
    /// <summary>
    ///     Команда принятия изменения выбранной Entity (принятия режима редактиования)
    /// </summary>
    public ICommand AcceptEditModeCommand { get; }
    
    /// <summary>
    ///     Команда удаления выбранной Entity
    /// </summary>
    public ICommand DeleteSelectedEntityCommand { get; }
    
    /// <summary>
    ///     Команда удаления выбранной связной Entity из коллекции
    /// </summary>
    public ICommand DeleteSubEntityFromCollectionCommand { get; }
    
    /// <summary>
    ///     Команда открытия режима добавления связной Entity в коллекцию
    /// </summary>
    public ICommand OpenAddSubEntityModeInCollectionCommand { get; }
    
    /// <summary>
    ///     Команда открытия режима смены связной Entity
    /// </summary>
    public ICommand OpenChangeSubEntityMode { get; }
    

    #endregion
}