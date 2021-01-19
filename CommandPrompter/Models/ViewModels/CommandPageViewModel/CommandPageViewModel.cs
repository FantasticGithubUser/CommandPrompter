using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos.Responses;
using CommandPrompter.Resources.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CommandPrompter.Models.ViewModels
{
    public class CommandPageViewModel : PageViewModel<CommandPage>
    {
        public ObservableCollection<CommandResponseDto> Commands { get; set; } = new ObservableCollection<CommandResponseDto>();
        public CommandPageViewModel(CommandPage page) : base(page)
        {
            var query = PageSwitchHelper.GetContext("CommandPageInitQuery") as List<QueryField>;
            if(query == null || query.Count == 0)
            {
                GetAllCommands();
            }
            else
            {
                _ = HttpRequestHelper.PostAsync<List<CommandResponseDto>>(RouteHelper.GetCommands, JsonConvert.SerializeObject(query), res =>
                {
                    UpdateUI(() =>
                    {
                        Commands.Clear();
                        foreach (var item in res)
                        {
                            Commands.Add(item);
                        }
                    });
                });
            }
        }

        private void GetAllCommands()
        {
            _ = HttpRequestHelper.GetAsync<List<CommandResponseDto>>(RouteHelper.GetAllCommands, res =>
            {
                UpdateUI(() =>
                {
                    Commands.Clear();
                    foreach (var item in res)
                    {
                        Commands.Add(item);
                    }
                });
            });
        }

    }
}
