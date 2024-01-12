using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0:
                    {
                        return "В процессе";
                    }
                case 1:
                    {
                        return "Завершенно";
                    }
                case 2:
                    {
                        return "Брошено";
                    }
                case 3:
                    {
                        return "В планах";
                    }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "В процессе":
                    {
                        return 0;
                    }
                case "Завершенно":
                    {
                        return 1;
                    }
                case "Брошено":
                    {
                        return 2;
                    }
                case "В планах":
                    {
                        return 3;
                    }
            }

            return 0;
        }
    }
}
