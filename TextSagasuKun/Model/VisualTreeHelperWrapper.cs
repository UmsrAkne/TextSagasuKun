using System.Windows;
using System.Windows.Media;

namespace TextSagasuKun.Model
{
    public static class VisualTreeHelperWrapper
    {
        public static T FindDescendant<T>(this DependencyObject depObj)
            where T : DependencyObject
        {
            if (depObj == null)
            {
                return null;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? FindDescendant<T>(child);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}