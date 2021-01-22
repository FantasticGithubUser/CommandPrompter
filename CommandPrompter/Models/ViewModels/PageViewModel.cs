using CommandPrompter.Helpers;
using CommandPrompter.Resources.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CommandPrompter.Models.ViewModels
{
    public abstract class PageViewModel<T> : SimpleViewModel where T : Page
    {
        protected T page;
        public PageViewModel(T page)
        {
            this.page = page;
        }
        protected void UpdateUI(Action action)
        {
            page.Dispatcher.Invoke(action);
        }

        public void TogglePopup()
        {
            var popup = FindDescendant<Popup>(page);
            if(popup != null)
            {
                popup.IsPoppedUp = !popup.IsPoppedUp;
            }
        }

        private static F FindDescendant<F>(DependencyObject d) where F : DependencyObject
        {
            if (d == null)
                return null;

            var childCount = VisualTreeHelper.GetChildrenCount(d);

            for (var i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(d, i);

                var result = child as F ?? FindDescendant<F>(child);

                if (result != null)
                    return result;
            }

            return null;
        }
    }
}
