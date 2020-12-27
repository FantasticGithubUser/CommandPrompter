using CommandPrompter.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CommandPrompter.Test
{
    public class TestWindowViewModel
    {
        public static TestWindowViewModel Instance { get
            {
                return new TestWindowViewModel();
            } }
        private TestWindowViewModel()
        {
            Users = new ObservableCollection<User>();
        }
        public ObservableCollection<User> Users { get; set; }
    }
}
