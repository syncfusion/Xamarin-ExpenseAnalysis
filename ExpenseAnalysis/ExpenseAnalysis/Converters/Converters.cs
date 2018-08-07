using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System.Collections;

namespace ExpenseAnalysis
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "Health & Wellness")
                return "health.png";
            return value.ToString().ToLower() + ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class SelectedItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class MonthExpenseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (value as ObservableCollection<TransactionDetail>)?.Where(j => j.Date.Month == 3);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class CellTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return double.Parse(value.ToString()) > 100 ? Color.White : Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class CellBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (double.Parse(value.ToString()) > 100)
                return Color.FromHex("#BF4D43");
            return double.Parse(value.ToString()) > 80 ? Color.FromHex("#DDA51E") : Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

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

    public class AutoCompleteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            var transactionDetail = new List<string>();
            var transactions = value as ObservableCollection<TransactionDetail>;
            foreach (var transaction in transactions.Where(transaction => !transactionDetail.Contains(transaction.Name))
                )
            {
                transactionDetail.Add(transaction.Name);
            }
            return transactionDetail;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class BudgetAvergeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double averageBudget = 0;
            for (var i = 0; i < ((ObservableCollection<ExpenseCategory>) value).Count; i++)
                averageBudget = averageBudget + ((ObservableCollection<ExpenseCategory>) value)[i].Budget;
            averageBudget = averageBudget/3;
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