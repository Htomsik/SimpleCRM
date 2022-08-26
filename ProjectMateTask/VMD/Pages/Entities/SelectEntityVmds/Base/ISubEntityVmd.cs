using System;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

internal interface ISubEntityVmd : IEntityVmd
{
     event Action<INamedEntity>? AddEntityNotifier;
}

