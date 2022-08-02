namespace ProjectMateTask.VMD.Base;

public abstract class BaseNotGenericEntityVmd:BaseVmd
{
    /// <summary>
    /// Название страницы
    /// </summary>
    public virtual string Tittle => "Не переопределенная страница";
    
    #region Режим редактирования

    protected bool _isEditMode ;

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

    
}