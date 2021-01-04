using CommandPrompter.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace CommandPrompter.Models.ViewModels
{
    public class SideMenuViewModel : BaseViewModel
    {
        public ObservableCollection<SideMenuItemViewModel> SideMenuItems { get; set; } = new ObservableCollection<SideMenuItemViewModel>();
        public SideMenuViewModel()
        {
            var plateform = new SideMenuItemViewModel(PageEnum.Plateform);
            plateform.Icon = Application.Current.TryFindResource("Plateform") as string;
            plateform.ItemName = "Plateform";
            SideMenuItems.Add(plateform);

            var command = new SideMenuItemViewModel(PageEnum.Command);
            command.Icon = Application.Current.TryFindResource("Command") as string;
            command.ItemName = "Command";
            SideMenuItems.Add(command);

            var commandChain = new SideMenuItemViewModel(PageEnum.CommandChain);
            commandChain.Icon = Application.Current.TryFindResource("Command") as string;
            commandChain.ItemName = "Command Chain";
            SideMenuItems.Add(commandChain);
        }
    }
}
