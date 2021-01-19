using CommandPrompter.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandPrompter.Models.ViewModels
{
    public class SimpleViewModel : BaseViewModel
    {
        public bool SwitchingPage { get; set; }
        public PageEnum SwitchPage { get; set; } = PageEnum.Welcome;
        public ICommand SwitchPageCommand { get; private set; }
        public SimpleViewModel()
        {
            SwitchPageCommand = new RelayCommand(async () => await ShowPageAsync());
        }

        protected async Task ShowPageAsync()
        {
            await RunCommandAsync(() => SwitchingPage, async () =>
            {
                await PageSwitchHelper.SwitchPage(SwitchPage);
            });
        }

        
    }
}
