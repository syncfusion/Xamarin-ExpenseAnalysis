using System;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public partial class AddTransactionsPage
    {
        public TransactionPage TransactionPage;

        public AddTransactionsPage()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Description.IsEnabled = true;
                    break;
            }
        }

        private void DoneButton_Clicked(object sender, EventArgs e)
        {
            if (CategoryPicker.SelectedIndex != -1)
            {
                var transaction = new TransactionDetail
                {
                    Category = CategoryPicker.Items[CategoryPicker.SelectedIndex],
                    Date = DateTimePicker.Date,
                    Spent = double.Parse(AmountSpent.Value.ToString()),
                    Name = Description.Text
                };
                ((ExpenseViewModel) BindingContext).AddTransaction(transaction);
                TransactionPage.CanNotify = true;
            }
            Navigation.PopToRootAsync();
        }

        private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Description.IsEnabled = true;
        }
    }
}