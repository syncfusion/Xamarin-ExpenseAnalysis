using Syncfusion.XForms.DataForm;
using System;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public partial class AddTransactionsPage
    {
        public TransactionPage TransactionPage;

        bool isDescriptionValid;

        public AddTransactionsPage()
        {
            InitializeComponent();
        }

        private void DoneButton_Clicked(object sender, EventArgs e)
        {
            isDescriptionValid = dataForm.Validate("ExpenseDescription");
            if (isDescriptionValid)
            {
                var newTransaction = ((ExpenseViewModel)BindingContext).SingleTransaction;
                if (newTransaction.Spent != 0)
                {
                    var transaction = new TransactionDetail
                    {
                        Category = newTransaction.Category.ToString(),
                        Date = newTransaction.Date,
                        Spent = newTransaction.Spent,
                        Name = newTransaction.ExpenseDescription
                    };
                    ((ExpenseViewModel)BindingContext).AddTransaction(transaction);
                    TransactionPage.CanNotify = true;
                }
                Navigation.PopToRootAsync();
            }
        }

        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
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