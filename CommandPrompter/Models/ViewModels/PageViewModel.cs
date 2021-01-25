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
        private Popup popup = null;
        protected Popup Popup 
        {
            get
            {
                if(popup == null)
                {
                    popup = MyVisualTreeHelper.FindChildByType<Popup>(page);
                }
                return popup;
            }
        }
        protected T page;
        public PageViewModel(T page)
        {
            this.page = page;
        }
        protected void UpdateUI(Action action)
        {
            page.Dispatcher.Invoke(action);
        }

        protected void TogglePopup()
        {
            if(Popup != null)
            {
                Popup.IsPoppedUp = true;
            }
        }
    }
}
