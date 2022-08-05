using System;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.VMD.Pages.SelectEntityPages;

public interface ISelectEntityVmd
{
     event Action<INamedEntity>? AddEntityNotifier;
}

