﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CommandPrompter.Resources
{
    public class ScrollViewerHelper
    {
        public static readonly DependencyProperty ShiftWheelScrollsHorizontallyProperty
        = DependencyProperty.RegisterAttached("ShiftWheelScrollsHorizontally",
            typeof(bool),
            typeof(ScrollViewerHelper),
            new PropertyMetadata(false, UseHorizontalScrollingChangedCallback));

        private static void UseHorizontalScrollingChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;

            if (element == null)
                throw new Exception("Attached property must be used with UIElement.");

            if ((bool)e.NewValue)
                element.PreviewMouseWheel += OnPreviewMouseWheel;
            else
                element.PreviewMouseWheel -= OnPreviewMouseWheel;
        }

        private static void OnPreviewMouseWheel(object sender, MouseWheelEventArgs args)
        {
            var scrollViewer = FindDescendant<ScrollViewer>(sender as DependencyObject);

            if (scrollViewer == null)
                return;

            if (Keyboard.Modifiers != ModifierKeys.Control)
                return;

            if (args.Delta < 0)
            {
                //Double the speed.
                scrollViewer.LineRight();
                scrollViewer.LineRight();
            }
            else
            {
                scrollViewer.LineLeft();
                scrollViewer.LineLeft();
            }

            args.Handled = true;
        }

        public static void SetShiftWheelScrollsHorizontally(ItemsControl element, bool value) => element.SetValue(ShiftWheelScrollsHorizontallyProperty, value);
        public static bool GetShiftWheelScrollsHorizontally(ItemsControl element) => (bool)element.GetValue(ShiftWheelScrollsHorizontallyProperty);

        private static T FindDescendant<T>(DependencyObject d) where T : DependencyObject
        {
            if (d == null)
                return null;

            var childCount = VisualTreeHelper.GetChildrenCount(d);

            for (var i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(d, i);

                var result = child as T ?? FindDescendant<T>(child);

                if (result != null)
                    return result;
            }

            return null;
        }

    }
}
