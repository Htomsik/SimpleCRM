﻿using System.ComponentModel;

namespace SimpleSRM.Models.Entities.Base;

/// <summary>
///        Entity c известным типом в бд. (Зачастую это Actor типы)
/// </summary>
public interface INamedEntity : IEntity, INotifyPropertyChanged,INotifyDataErrorInfo
{
    /// <summary>
    ///     Наименование
    /// </summary>
    string Name { get; set; } 
}