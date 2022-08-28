using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;

namespace Wpf.UI.Converter
{
    internal class HorizontalThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness thickness)
            {
                return new Thickness(thickness.Left, 0, thickness.Right, 0);
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    internal class RemoveAlphaBrushConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is SolidColorBrush brush
                ? new SolidColorBrush(RgbaToRgb(brush.Color, parameter))
                : Binding.DoNothing;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            => values[0] is SolidColorBrush brush
                ? new SolidColorBrush(RgbaToRgb(brush.Color, values[1]))
                : Binding.DoNothing;

        private static Color RgbaToRgb(Color rgba, object background)
        {

            var backgroundColor = Colors.White;

            var alpha = (double)rgba.A / byte.MaxValue;
            var alphaReverse = 1 - alpha;

            return Color.FromRgb(
                (byte)(alpha * rgba.R + alphaReverse * backgroundColor.R),
                (byte)(alpha * rgba.G + alphaReverse * backgroundColor.G),
                (byte)(alpha * rgba.B + alphaReverse * backgroundColor.B)
            );
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
    internal class NotZeroToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double val;
            double.TryParse((value ?? "").ToString(), out val);

            return Math.Abs(val) > 0.0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
    internal class TopThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is Thickness thickness
                ? new Thickness(0, thickness.Top, 0, 0)
                : Binding.DoNothing;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

    internal class GridLinesVisibilityBorderToThicknessConverter : IValueConverter
    {
        private const double GridLinesThickness = 1;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DataGridGridLinesVisibility visibility))
                return Binding.DoNothing;

            var thickness = parameter as double? ?? GridLinesThickness;

            switch (visibility)
            {
                case DataGridGridLinesVisibility.All:
                    return new Thickness(0, 0, thickness, thickness);
                case DataGridGridLinesVisibility.Horizontal:
                    return new Thickness(0, 0, 0, thickness);
                case DataGridGridLinesVisibility.None:
                    return new Thickness(0, 0, thickness, 0);
                case DataGridGridLinesVisibility.Vertical:
                    return new Thickness(0);
                default:
                    throw new ArgumentOutOfRangeException();
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }

}
