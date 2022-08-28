using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.UI.Assist
{
    public static class ListViewAssist
    {
        public static readonly DependencyProperty ListViewItemPaddingProperty = DependencyProperty.RegisterAttached(
            "ListViewItemPadding",
            typeof(Thickness),
            typeof(ListViewAssist),
            new FrameworkPropertyMetadata(new Thickness(8, 8, 8, 8), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetListViewItemPadding(DependencyObject element, Thickness value)
        {
            element.SetValue(ListViewItemPaddingProperty, value);
        }

        public static Thickness GetListViewItemPadding(DependencyObject element)
        {
            return (Thickness)element.GetValue(ListViewItemPaddingProperty);
        }
    }
}
