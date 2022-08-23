using System;
using MaterialDesignThemes.Wpf;

namespace ProjectMateTask.Models.AppInfrastructure;

internal sealed class MenuNavigationTypeItem : MenuItem
{
    public Type VmdType { get; }

    public MenuNavigationTypeItem(string name, PackIconKind materialIconName, Type vmdType)  : base(name, materialIconName)
    {
        VmdType = vmdType;
    }
}