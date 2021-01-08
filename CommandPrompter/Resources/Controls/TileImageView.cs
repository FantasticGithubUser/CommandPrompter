using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CommandPrompter.Resources.Controls
{
    public class TileImageView : ViewBase
    {
        private DataTemplate itemTemplate;
        public DataTemplate ItemTemplate
        {
            get
            {
                return itemTemplate;
            }
            set
            {
                itemTemplate = value;
            }
        }
        protected override object DefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileImageView"); }
        }

        protected override object ItemContainerDefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileImageViewItem"); }
        }
    }
}
