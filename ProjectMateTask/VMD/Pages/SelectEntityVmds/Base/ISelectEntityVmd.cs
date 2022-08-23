using System;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.VMD.Pages.SelectEntityVmds.Base;

public interface ISelectEntityVmd
{
     event Action<INamedEntity>? AddEntityNotifier;
}

