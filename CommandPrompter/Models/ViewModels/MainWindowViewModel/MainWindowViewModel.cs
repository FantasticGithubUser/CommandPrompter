using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos;
using Newtonsoft.Json;
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
            Users = new ObservableCollection<UserResponseDto>();
            var login = new LoginRequestDto()
            {
                username = "test",
                password = "test"
            };
            var info = JsonConvert.SerializeObject(login);
            var token = HttpRequestHelper.PostAsync<TokenResponseDto>(RouteHelper.Login, info).ContinueWith(res =>
            {
                AccountHolder.Token = res.Result.Token;
                HttpRequestHelper.AddJWTBearer();
                var users = HttpRequestHelper.GetAsync<List<UserResponseDto>>(RouteHelper.GetAllUsers).ContinueWith(res =>
                {
                    foreach (var item in res.Result)
                    {
                        window.Dispatcher.Invoke(() =>
                        {
                            Users.Add(item);
                        });
                    }
                });
            });
            

        }

        public ObservableCollection<UserResponseDto> Users { get; set; }
 
    }
}
