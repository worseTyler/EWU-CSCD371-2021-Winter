using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfApp
{
    public class EmptyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrWhiteSpace((string)value))
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(EqualityComparer<object>.Default.Equals(Visibility.Visible, value))
            {
                return "Visible";
            } else if(EqualityComparer<object>.Default.Equals(Visibility.Collapsed, value))
            {
                return "Collapsed";
            }
            else
            {
                throw new ArgumentException($"Convert Back in EmptyStringConverter doesn't have a valid conversion for {nameof(value)}");
            }
        }
    }
}
