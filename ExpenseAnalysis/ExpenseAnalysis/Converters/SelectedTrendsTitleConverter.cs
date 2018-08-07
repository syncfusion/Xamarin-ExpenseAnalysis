using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class SelectedTrendsTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Get the month number from anonymous class and return the month name using date time format.
            if (((IList)value).Count != 0)
                return
                    new DateTime(2000,
                        (int)char.GetNumericValue(((IList)value)[0].ToString().Split('=')[4].ToCharArray()[1]), 1)
                        .ToString("MMMM");
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
