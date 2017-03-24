using System.Collections.Generic;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public partial class MasterPage
    {
        public ListView ListView => MasterDetailListView;

        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = "Overview",
                    IconSource = "user.png",
                    TargetType = typeof (OverviewPage)
                },
                new MasterPageItem
                {
                    Title = "Transaction",
                    IconSource = "message.png",
                    TargetType = typeof (TransactionPage)
                },
                new MasterPageItem
                {
                    Title = "Category/Budget",
                    IconSource = "category.png",
                    TargetType = typeof (CategoryBudgetPage)
                },
                new MasterPageItem
                {
                    Title = "Trends",
                    IconSource = "trend.png",
                    TargetType = typeof (TrendsPage)
                }
            };
            MasterDetailListView.ItemsSource = masterPageItems;

            Device.OnPlatform(() => mailId.FontSize = 12);
        }
    }
}