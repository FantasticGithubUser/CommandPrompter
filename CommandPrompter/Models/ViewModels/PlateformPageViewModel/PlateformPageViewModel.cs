using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos.Responses;
using CommandPrompter.Resources.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace CommandPrompter.Models.ViewModels
{
    public class PlateformPageViewModel : PageViewModel<PlateformPage>
    {
        public ObservableCollection<PlateformResponseDto> Plateforms { get; private set; } = new ObservableCollection<PlateformResponseDto>();
        public PlateformPageViewModel(PlateformPage page) : base(page)
        {
            var query = PageSwitchHelper.GetContext("PlateformPageInitQuery") as List<QueryField>;
            if (query == null || query.Count == 0)
            {
                GetAllPlateforms();
            }
            else
            {
                _ = HttpRequestHelper.PostAsync<List<PlateformResponseDto>>(RouteHelper.GetPlateforms, JsonConvert.SerializeObject(query), res =>
                {
                    UpdateUI(() =>
                    {
                        Plateforms.Clear();
                        foreach (var item in res)
                        {
                            Plateforms.Add(item);
                        }
                    });
                });
            }
        }
        public void GetAllPlateforms()
        {
            _ = HttpRequestHelper.GetAsync<List<PlateformResponseDto>>(RouteHelper.GetAllPlateforms, res =>
            {
                UpdateUI(() =>
                {
                    Plateforms.Clear();
                    foreach (var item in res)
                    {
                        Plateforms.Add(item);
                    }
                });
            });
        }
    }
}
