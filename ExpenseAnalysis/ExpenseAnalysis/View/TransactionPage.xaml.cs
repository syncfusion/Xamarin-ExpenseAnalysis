using System;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public partial class TransactionPage
    {
        public bool CanNotify { get; set; }

        private readonly ExpenseViewModel viewModel;

        public TransactionPage()
        {
            InitializeComponent();
            viewModel = (BindingContext as ExpenseViewModel);
            if (Device.RuntimePlatform != "UWP") return;
            AddTransactionsButton.Text = "Add Transaction";
            OptionsButton.Text = "GroupBy";
        }

        private async void OptionsButton_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet(null, "Cancel", null, "View by category", "View by date");

            if (action == null) return;

            if (action == "View by category")
            {
                GroupingListView.ItemTemplate = Resources["ExpenseByCategory"] as DataTemplate;
                viewModel.GroupBy("Category");
                GroupingListView.GroupHeaderTemplate = Resources["ExpenseByCategoryHeader"] as DataTemplate;
            }
            else if (action == "View by date")
            {
                GroupingListView.ItemTemplate = Resources["ExpenseByDate"] as DataTemplate;
                viewModel.GroupBy("Date");
                GroupingListView.GroupHeaderTemplate = Resources["ExpenseByDateHeader"] as DataTemplate;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (CanNotify)
            {
                viewModel.NotifyPropertyChanged("Transactions");
                CanNotify = false;
            }
        }

        private void addTransactionsButton_Clicked(object sender, EventArgs e)
        {
            ((ExpenseViewModel)BindingContext).SingleTransaction = new AddTransactionDetail { Date = new DateTime(2018, 03, 01) };
            Navigation.PushAsync(new AddTransactionsPage()
            {
                BindingContext = BindingContext,
                TransactionPage = this
            });
        }
    }
}