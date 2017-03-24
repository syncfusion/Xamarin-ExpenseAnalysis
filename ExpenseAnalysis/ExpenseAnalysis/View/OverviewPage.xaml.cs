using Syncfusion.SfDataGrid.XForms;

namespace ExpenseAnalysis
{
    public partial class OverviewPage
    {
        public OverviewPage()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            ((ExpenseViewModel) BindingContext).SelectedCategory = ((ExpenseCategory) e.AddedItems[0]).Name;
            Navigation.PushAsync(new CategoryDetailPage {BindingContext = BindingContext});
        }
    }
}