﻿using CommandPrompter.Helpers;
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

namespace CommandPrompter.Resources.Pages
{
    /// <summary>
    /// PlateformPage.xaml 的交互逻辑
    /// </summary>
    public partial class PlateformPage : Page
    {
        public PlateformPage()
        {
            InitializeComponent();
            this.DataContext = new PlateformPageViewModel(this);
        }

        private void ListViewItem_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (sender != null)
            {
                (this.DataContext as PlateformPageViewModel)?.ShowPopup((PlateformResponseDto)item.DataContext);
                e.Handled = true;
            }
        }
    }
}
