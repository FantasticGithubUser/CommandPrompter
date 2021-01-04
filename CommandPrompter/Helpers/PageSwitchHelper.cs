using CommandPrompter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompter.Helpers
{
    /// <summary>
    /// The page schedule helper.
    /// </summary>
    public static class PageSwitchHelper
    {
        public static MainWindowViewModel windowViewModel { get; set; }

        public static async Task SwitchPage(PageEnum page)
        {
            windowViewModel.CurrentPage = page;
        }
    }
    
}
