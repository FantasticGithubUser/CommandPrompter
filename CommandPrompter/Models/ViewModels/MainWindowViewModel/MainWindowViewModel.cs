using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace CommandPrompter.Models.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Window window;

        private PageEnum currentPage = PageEnum.Welcome;
        public PageEnum CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public MainWindowViewModel(Window window)
        {
            PageSwitchHelper.windowViewModel = this;
            this.window = window;
            var login = new LoginRequestDto()
            {
                username = "test",
                password = "test"
            };
            var info = JsonConvert.SerializeObject(login);
            var token = HttpRequestHelper.PostAsync<TokenResponseDto>(RouteHelper.Login, info, res =>
            {
                AccountHolder.Token = res.Token;
                HttpRequestHelper.AddJWTBearer();
            });


        }

 
    }
}
