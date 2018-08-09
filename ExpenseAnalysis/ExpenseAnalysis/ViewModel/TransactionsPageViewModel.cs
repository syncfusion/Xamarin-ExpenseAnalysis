using Syncfusion.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class TransactionsPageViewModel : ExpenseViewModelBase
    {
        /// <summary>
        /// Gets or sets DataSource to group the trasactions to be display in SfListView
        /// </summary>
        public DataSource GroupingDataSource { get; set; }
        public ICommand AddNewTransactionCommand { get; set; }
        public TransactionsPageViewModel()
        {
            AddNewTransactionCommand = new Command(execute: AddNewTransactionClicked);
            GroupingDataSource = new DataSource();
            GroupingDataSource.GroupDescriptors.Add(new GroupDescriptor { PropertyName = "Category" });
            GroupingDataSource.SortDescriptors.Add(new SortDescriptor
            {
                PropertyName = "Date",
                Direction = ListSortDirection.Descending
            });
        }

        /// <summary>
        /// Groups the DataSource based on given property
        /// </summary>
        /// <param name="propertyName"></param>
        public void GroupBy(string propertyName)
        {
            GroupingDataSource.GroupDescriptors.Clear();
            GroupingDataSource.GroupDescriptors.Add(new GroupDescriptor { PropertyName = propertyName });
            GroupingDataSource.SortDescriptors.Clear();
            GroupingDataSource.SortDescriptors.Add(new SortDescriptor
            {
                PropertyName = "Date",
                Direction = ListSortDirection.Descending,
            });
        }

        public void AddNewTransactionClicked()
        {
            NavigationService.NavigateToPage(typeof(AddTransactionsPageViewModel), Transactions);
        }
    }
}
