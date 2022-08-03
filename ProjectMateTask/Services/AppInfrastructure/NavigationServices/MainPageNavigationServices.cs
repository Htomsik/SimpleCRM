﻿using System;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

internal sealed class MainPageNavigationServices:BaseNavigationServices<BaseNotGenericEntityVmd>
{
    public MainPageNavigationServices(INavigationStore navigationStore, Func<BaseNotGenericEntityVmd> createVmd) : base(navigationStore, createVmd)
    {
    }

   
}