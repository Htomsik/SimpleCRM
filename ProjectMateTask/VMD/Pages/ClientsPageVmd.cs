using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Models;

using ProjectMateTask.VMD.Base;
using ProjectMateTask.VW;

namespace ProjectMateTask.VMD.Pages;

public class ClientsPageVmd:BaseVmd
{
    public ObservableCollection<Client> Clients { get; }

    public ClientsPageVmd()
    {
        Clients = new ObservableCollection<Client>();
        
        
    }
    


  

}