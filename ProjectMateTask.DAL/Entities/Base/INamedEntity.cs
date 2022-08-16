﻿using System.ComponentModel;

namespace ProjectMateTask.DAL.Entities.Base;

public interface INamedEntity : IEntity, INotifyPropertyChanged
{
    string Name { get; set; }
}