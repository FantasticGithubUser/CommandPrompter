using CommandPrompter.Models.Dtos.Responses;
using CommandPrompter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandPrompter.Resources.Controls
{
    public class SearchBar : Control
    {
        #region DependencyProperties registration
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SearchBar), new PropertyMetadata("", TextChangedCallback));

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(SearchBar), new PropertyMetadata(false, IsExpandedChangedCallback));

        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register("IsLoading", typeof(bool), typeof(SearchBar), new PropertyMetadata(false, IsLoadingChangedCallback));

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(RelatedNameResponseDto), typeof(SearchBar), new PropertyMetadata(null, SelectedItemChangedCallback));

        public string MyText
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }
        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }
        public RelatedNameResponseDto SelectedItem
        {
            get => (RelatedNameResponseDto)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        #endregion
        private static void SelectedItemChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var searchBar = d as SearchBar;
            searchBar.IsExpanded = false;
            searchBar.IsLoading = false;
            var newValue = e.NewValue as RelatedNameResponseDto;
            if(newValue != null)
            {
                (searchBar.DataContext as SearchBarViewModel).ClearRelatedNames();
            }
        }

        private static void IsLoadingChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private static void IsExpandedChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == false)
            {
                (d as SearchBar).IsLoading = false;
            }
        }

        private static void TextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var searchBar = d as SearchBar;
            var context = searchBar.DataContext as SearchBarViewModel;
            context.GetRelatedNames((string)e.NewValue);
        }

        static SearchBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchBar), new FrameworkPropertyMetadata(typeof(SearchBar)));
        }
        public SearchBar()
        {
            this.DataContext = new SearchBarViewModel(this);
            EventManager.RegisterClassHandler(typeof(SearchBar), LostFocusEvent, new RoutedEventHandler((sender, e)=>
            {
                (sender as SearchBar).IsExpanded = false;
            }));
        }
    }
}
