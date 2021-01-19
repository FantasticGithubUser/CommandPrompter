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
        private static Dictionary<string, object> Context { get; set; } = new Dictionary<string, object>();
        public static async Task SwitchPage(PageEnum page)
        {
            windowViewModel.CurrentPage = page;
        }

        public static void PutContext(string key, object contextInfo)
        {
            if (Context.ContainsKey(key) == true)
            {
                Context[key] = contextInfo;
            }
            else
            {
                Context.Add(key, contextInfo);
            }
        }
        public static object GetContext(string key)
        {
            if (Context.ContainsKey(key) == true)
            {
                var obj = Context[key];
                Context.Remove(key);
                return obj;
            }
            else
            {
                return null;
            }
        }
    }
    
}
