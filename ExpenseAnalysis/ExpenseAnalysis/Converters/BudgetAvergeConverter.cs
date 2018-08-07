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
    public class BudgetAvergeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double averageBudget = 0;
            for (var i = 0; i < ((ObservableCollection<ExpenseCategory>)value).Count; i++)
                averageBudget = averageBudget + ((ObservableCollection<ExpenseCategory>)value)[i].Budget;
            averageBudget = averageBudget / 3;
            var dataPoints = new ObservableCollection<ChartDataPoint>
            {
                new ChartDataPoint(1, averageBudget),
                new ChartDataPoint(2, averageBudget)
            };
            return dataPoints;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
