using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic
{
    public class EstimationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 1)
            {
                return "Легенда";
            }

            if ((int)value == 2)
            {
                return "Super good";
            }

            if ((int)value == 3)
            {
                return "It's okay";
            }

            if ((int)value == 4)
            {
                return "Не очень";
            }

            if ((int)value == 5)
            {
                return "Говно";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "Легенда")
            {
                return 1;
            }

            if ((string)value == "Super good")
            {
                return 2;

            }

            if ((string)value == "It's okay")
            {
                return 3;
            }

            if ((string)value == "Не очень")
            {
                return 4;
            }

            if ((string)value == "Говно")
            {
                return 5;
            }

            return 0;
        }
    }
}
