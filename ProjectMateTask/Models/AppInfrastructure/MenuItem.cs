using MaterialDesignThemes.Wpf;

namespace ProjectMateTask.Models.AppInfrastructure;

public class MenuItem
{
    public  string Name { get; }

    public  PackIconKind MaterialIcon { get; }


    public MenuItem(string name, PackIconKind materialIconName)
    {
        Name = name;
        
        MaterialIcon= materialIconName;
    }
}