using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Breath.Converters
{
    class BoolToVisibilityConverter : IValueConverter
    {
        public bool Negate { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var b = (bool) value;

            return (Negate ? !b : b) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
