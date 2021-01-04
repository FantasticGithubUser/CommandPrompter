using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommandPrompter.Models.ViewModels
{
    public class SideMenuItemViewModel :BaseViewModel
    {
        private object lockObject = new object();
        public ICommand command { get; private set; }

        private Type pageType { get; set; }
        public SideMenuItemViewModel(Type pageType)
        {
            if (!pageType.IsSubclassOf(typeof(Page)))
                throw new ArgumentException($"{pageType.FullName} is not the subclass of {typeof(Page).FullName}!");
            this.pageType = pageType;
        }

        
    }
}
