using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
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
}
