using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class MonthSpentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var transactions = value as ObservableCollection<TransactionDetail>;

            var groupedValue = transactions.GroupBy(item => item.Date.Month);
            var dataPoints = new ObservableCollection<ChartDataPoint>();

            foreach (var trans in groupedValue)
            {
                dataPoints.Add(new ChartDataPoint(new DateTime(trans.FirstOrDefault().Date.Year, trans.Key, trans.Key),
                    trans.Sum(item => item.Spent)));
            }
            return dataPoints;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
