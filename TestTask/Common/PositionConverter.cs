using System;
using System.Globalization;
using System.Windows.Data;
using TestTask.Model.Entities;

namespace TestTask.Common
{
    public class PositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is Position p ? p switch
            {
                Position.Manager => "Руководитель",
                Position.Worker  => "Работник",
                _                => value.ToString()
            } : value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
