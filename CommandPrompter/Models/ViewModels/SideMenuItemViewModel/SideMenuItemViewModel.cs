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
    public class SideMenuItemViewModel :BaseViewModel
    {
        public bool CommandRunning { get; private set; }
        public ICommand openPageCommand { get; private set; }

        public string Icon { get; set; }
        public string ItemName { get; set; }

        private PageEnum page { get; set; }
        public SideMenuItemViewModel(PageEnum page)
        {
            this.page = page;
            openPageCommand = new RelayCommand(async () => await ShowPageAsync());

        }

        private async Task ShowPageAsync()
        {
            await RunCommandAsync(() => CommandRunning, async () =>
            {
                await PageSwitchHelper.SwitchPage(page);
            });
        }

        
    }
}
