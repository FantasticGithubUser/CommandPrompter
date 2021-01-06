using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos.Responses;
using CommandPrompter.Resources.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace CommandPrompter.Models.ViewModels.PlateformPageViewModel
{
    public class PlateformPageViewModel : PageViewModel<PlateformPage>
    {
        public ObservableCollection<PlateformResponseDto> Plateforms { get; private set; } = new ObservableCollection<PlateformResponseDto>();
        public PlateformPageViewModel(PlateformPage page) : base(page)
        {
            GetAllPlateforms();
        }

        private void GetAllPlateforms()
        {
            _ = HttpRequestHelper.GetAsync<List<PlateformResponseDto>>(RouteHelper.GetAllPlateforms, res =>
            {
                UpdateUI(() =>
                {
                    foreach (var item in res)
                    {
                        Plateforms.Add(item);
                    }
                });
            });
        }
    }
}
