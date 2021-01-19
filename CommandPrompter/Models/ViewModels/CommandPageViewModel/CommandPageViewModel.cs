using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos.Responses;
using CommandPrompter.Resources.Pages;
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
            GetAllCommands();
        }

        private void GetAllCommands()
        {
            _ = HttpRequestHelper.GetAsync<List<CommandResponseDto>>(RouteHelper.GetAllCommands, res =>
            {
                UpdateUI(() =>
                {
                    foreach (var item in res)
                    {
                        Commands.Add(item);
                    }
                });
            });
        }

    }
}
