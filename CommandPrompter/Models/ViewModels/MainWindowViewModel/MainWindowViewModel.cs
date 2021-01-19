using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos;
using CommandPrompter.Resources.Pages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CommandPrompter.Models.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Window window;

        private PageEnum currentPage;
        public PageEnum CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                Page newPage = null;
                switch (currentPage)
                {
                    case PageEnum.Error:
                        newPage = new ErrorPage();
                        break;
                    case PageEnum.Plateform:
                        newPage = new PlateformPage();
                        break;
                    case PageEnum.Command:
                        newPage = new CommandPage();
                        break;
                    case PageEnum.CommandChain:
                        newPage = new CommandChainPage();
                        break;
                    case PageEnum.CommandParameter:
                        newPage = new CommandParameterPage();
                        break;
                    case PageEnum.User:
                        newPage = new UserPage();
                        break;
                    case PageEnum.Welcome:
                    default:
                        newPage = new WelcomePage();
                        break;
                }
                (window.FindName("PageFrame") as Frame).Navigate(newPage);
            }
        }
        public MainWindowViewModel(Window window)
        {
            PageSwitchHelper.windowViewModel = this;
            this.window = window;
            CurrentPage = PageEnum.Welcome;
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
