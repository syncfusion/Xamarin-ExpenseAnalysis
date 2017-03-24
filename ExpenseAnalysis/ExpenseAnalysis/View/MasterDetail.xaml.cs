using System;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public partial class MasterDetail
    {
        public MasterDetail()
        {
            InitializeComponent();
            RootPage.ListView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;

            if (item == null) return;

            Detail = new NavigationPage((Page) Activator.CreateInstance(item.TargetType))
            {
                BarBackgroundColor = Color.FromHex("#4834AF"),
                BarTextColor = Color.White
            };

            RootPage.ListView.SelectedItem = null;
            IsPresented = false;
        }
    }
}