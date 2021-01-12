using CommandPrompter.Helpers;
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
    public class SideMenuItemViewModel :SimpleViewModel
    {
        public bool CommandRunning { get; private set; }

        public string Icon { get; set; }
        public string ItemName { get; set; }

        
        public SideMenuItemViewModel(PageEnum page)
        {
            this.SwitchPage = page;
        }

       

        
    }
}
