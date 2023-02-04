using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;
using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTask.Infrastructure.Selectors;

/// <summary>
///     Селектор выбора карт для Entity
/// </summary>
public class EditEntitySelector : DataTemplateSelector
{
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        var element = container as FrameworkElement;

        try
        {
            if (element != null && item != null)
            {
                
                var resource = element.FindResource(EditCardByEntity[item.GetType()]);

                if (resource is null)
                    throw new ArgumentNullException($"Не найдена карточка редактирования для {nameof(item)}");

                return resource as DataTemplate;
            }
        }
        catch (Exception)
        {
            return null;
        }
     

        return null;
    }

    /// <summary>
    ///     Словарь сопоставления Entity с карточками редактирования
    /// </summary>
    private static readonly Dictionary<Type, string> EditCardByEntity = new()
    {
        { typeof(Client), "EditClientCard" },
        { typeof(Product),  "EditProductCard" },
        { typeof(Manager), "EditManagerCard" },
        { typeof(ProductType), "EditProductTypeCard" },
        { typeof(ClientStatus), "EditClientStatusCard" }
        
    };
}