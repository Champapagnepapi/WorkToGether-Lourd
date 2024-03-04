using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WorkToGether.Converters
{
    internal class ObjectToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = Visibility.Collapsed;

            if (value != null && value != DependencyProperty.UnsetValue)
            {
                if ((string)parameter == "!")
                {
                    visibility = Visibility.Collapsed;
                }
                else
                {
                    visibility = Visibility.Visible;

                }
            }
            else
            {
                if ((string)parameter == "!")
                {
                    visibility = Visibility.Visible;
                }
                else
                {
                    visibility = Visibility.Collapsed;

                }
            }



            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
