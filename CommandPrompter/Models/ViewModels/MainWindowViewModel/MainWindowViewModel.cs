using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CommandPrompter.Models.ViewModels
{
    public class MainWindowViewModel
    {
        public static MainWindowViewModel Instance => new MainWindowViewModel();

        private MainWindowViewModel()
        {
            Users = new ObservableCollection<User>();
            var users = HttpRequestHelper.GetAsync<List<User>>(RouteHelper.GetAllUsers);
            foreach (var item in users.Result)
            {
                Users.Add(item);
            }
        }

        public ObservableCollection<User> Users { get; set; }
    }
}
