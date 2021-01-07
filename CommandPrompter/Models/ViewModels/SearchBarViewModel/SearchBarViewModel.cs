using CommandPrompter.Helpers;
using CommandPrompter.Models.Dtos.Responses;
using CommandPrompter.Resources.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CommandPrompter.Models.ViewModels.SearchBarViewModel
{
    public class SearchBarViewModel : BaseViewModel
    {
        private SearchBar searchBar;
        public ObservableCollection<RelatedNameResponseDto> RelatedNames { get; set; } = new ObservableCollection<RelatedNameResponseDto>();
        public SearchBarViewModel(SearchBar searchBar)
        {
            this.searchBar = searchBar;
        }
        public void GetRelatedNames(string name = "", int count = 10)
        {
            RelatedNames.Clear();
            searchBar.IsLoading = true;
            searchBar.IsExpanded = true;
            if (!string.IsNullOrEmpty(name))
            {
                _ = HttpRequestHelper.GetAsync<List<RelatedNameResponseDto>>(RouteHelper.ReplaceParam(RouteHelper.GetRelatedNames, name, count.ToString()), res =>
                   {
                       searchBar.Dispatcher.Invoke(() =>
                       {
                           if (res != null)
                           {
                               foreach (var item in res)
                               {
                                   RelatedNames.Add(item);
                               }
                           }
                           searchBar.IsLoading = false;
                       });
                   });
            }
        }
        public void ClearRelatedNames()
        {
            RelatedNames.Clear();
        }
    }
}
