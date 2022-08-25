using System;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

public interface ISelectEntityVmd
{
     event Action<INamedEntity>? AddEntityNotifier;
}

