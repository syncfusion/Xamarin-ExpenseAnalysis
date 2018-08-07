using System;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public partial class TransactionPage
    {
        private readonly TransactionsPageViewModel viewModel;

        public TransactionPage()
        {
            InitializeComponent();
            viewModel = (BindingContext as TransactionsPageViewModel);

            if (Device.RuntimePlatform != Device.macOS)
            {
                var optionsButton = new ToolbarItem
                {
                    Order = ToolbarItemOrder.Primary,
                    Priority = 1,
                    Icon = "filter.png",
                    Text = "GroupBy"
                };

                optionsButton.Clicked += OptionsButton_Clicked;
                ToolbarItems.Add(optionsButton);
            }
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
            viewModel.NotifyPropertyChanged("Transactions");
        }
    }
}