namespace ProjectMateTask.VMD.Base;

internal abstract class BaseNotGenericEntityVmd:BaseVmd
{
    /// <summary>
    /// Название страницы
    /// </summary>
    public virtual string Tittle { get; }
    
    #region Режим редактирования

    private bool _isEditMode;

    /// <summary>
    /// Указывает, запущен ли режим редактирования Entity обьекта
    /// </summary>
    public virtual bool IsEditMode
    {
        get => _isEditMode;
        set
        {
            Set(ref _isEditMode, value);
        }
    }

    #endregion


    public BaseNotGenericEntityVmd()
    {
        Tittle = "Тестовая стрница";
    }
}