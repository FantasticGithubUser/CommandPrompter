using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace CommandPrompter.Models.ViewModels
{
    public class MainWindowViewModel
    {
        private Window window;
        public MainWindowViewModel(Window window)
        {
            this.window = window;
            Users = new ObservableCollection<User>();
            var users = HttpRequestHelper.GetAsync<List<User>>(RouteHelper.GetAllUsers).ContinueWith( res =>
            {
                foreach (var item in res.Result)
                {
                    window.Dispatcher.Invoke(() =>
                    {
                        Users.Add(item);
                    });
                }
            });
            
        }

        public ObservableCollection<User> Users { get; set; }
 
    }
}
