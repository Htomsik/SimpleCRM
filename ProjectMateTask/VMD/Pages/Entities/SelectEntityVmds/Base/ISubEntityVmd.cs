using System;
using System.Windows.Input;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

/// <summary>
///     Модель представления для SubEntity типов
/// </summary>
internal interface ISubEntityVmd : IEntityVmd
{
    /// <summary>
    ///     Команда передачи выбранного subEntity (связного) типа в MainEntity
    /// </summary>
    public ICommand AddSubEntityToMainEntityCommand { get; }

    /// <summary>
    ///     Команда закрытия SubEntity (связного) vmd типа
    /// </summary>
    public ICommand CloseSubEntityPageCommand { get; }

    /// <summary>
    ///     Уведомитель-передатчик о том, что subEntity (связный) тип была выбрана
    /// </summary>
    event Action<INamedEntity>? AddEntityNotifier;
}