using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjectMateTask.Infrastructure.Selectors;

public class EditEntitySelector : DataTemplateSelector
{
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        var element = container as FrameworkElement;

        try
        {
            if (element != null && item != null)
            {
                
                var itemtype = item.GetType();
                
                var resource = element.FindResource($"Edit{itemtype.Name}Card");

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
}