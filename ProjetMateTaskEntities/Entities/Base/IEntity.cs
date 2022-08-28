namespace ProjetMateTaskEntities.Entities.Base;

/// <summary>
///    Entity c неизвестным типом в бд. (На случай если неизвестно что это за тип)
/// </summary>
public interface IEntity : ICloneable, IEquatable<object>
{
    /// <summary>
    ///     Идентификатор сущности в бд
    /// </summary>
    int Id { get; set; }
}