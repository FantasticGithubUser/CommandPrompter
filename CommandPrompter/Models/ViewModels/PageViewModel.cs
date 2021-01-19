using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
    }
}
