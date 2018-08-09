using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class AddTransactionsPageViewModel : ExpenseViewModelBase
    {
        public object CategorySelected { get; set; }

        public double SpentOn { get; set; }

        public string ExpenseDescription { get; set; }

        public DateTime Date { get; set; } = new DateTime(2018, 3, 1);

        public ICommand AddNewDataCommand { get; set; }

        public ICommand AutoGeneratingColumnsCommand { get; set; }

        public AddTransactionsPageViewModel()
        {
            SingleTransaction = new AddTransactionDetail { Date = new DateTime(2018, 03, 01) };
            AddNewDataCommand = new Command(execute: AddNewTransactions);
            AutoGeneratingColumnsCommand = new Command(execute: AutoGenerateColumns);
        }

        public void AddNewTransactions()
        {
            if (Device.RuntimePlatform == Device.macOS)
            {
                if (CategorySelected != null)
                {
                    var transaction = new TransactionDetail
                    {
                        Category = CategorySelected.ToString(),
                        Date = Date,
                        Spent = SpentOn,
                        Name = ExpenseDescription
                    };

                    App.DataService.InsertTansaction(transaction);
                    Transactions.Add(transaction);
                    NavigationService.NavigatePopToRoot();
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(SingleTransaction.ExpenseDescription))
                {
                    var newTransaction = SingleTransaction;
                    var transaction = new TransactionDetail
                    {
                        Category = newTransaction.Category.ToString(),
                        Date = newTransaction.Date,
                        Spent = newTransaction.Spent,
                        Name = newTransaction.ExpenseDescription
                    };
                    App.DataService.InsertTansaction(transaction);
                    Transactions.Add(transaction);
                    NavigationService.NavigatePopToRoot();
                }
            }
        }

        public void AutoGenerateColumns(object autoGeneratingDataFormItemEventArgs)
        {
            AutoGeneratingDataFormItemEventArgs e = autoGeneratingDataFormItemEventArgs as AutoGeneratingDataFormItemEventArgs;
            if (e.DataFormItem != null && e.DataFormItem.Name == "Date")
            {
                (e.DataFormItem as DataFormDateItem).MinimumDate = new DateTime(2018, 1, 1);
                (e.DataFormItem as DataFormDateItem).MaximumDate = new DateTime(2018, 3, 31);
            }

            if (e.DataFormItem != null && e.DataFormItem.Name == "Spent")
            {
                (e.DataFormItem as DataFormNumericItem).FormatString = "c";
            }
        }
    }
}
