using Syncfusion.DataSource;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class ExpenseViewModel : INotifyPropertyChanged
    {
        private double _spent;
        private double _balance;
        private double _trendSpent;
        private ExpenseCategory _selectedCategory;
        private object _selectedItem;
        private ObservableCollection<TransactionDetail> _transactions;
        private ObservableCollection<ExpenseCategory> _categories;
        private IEnumerable _selectedTrends;

        public double SpentOn { get; set; }

        public object CategorySelected { get; set; }

        public string ExpenseDescription { get; set; }

        public DateTime Date { get; set; } = new DateTime(2018, 3, 1);

        public enum CategoryPicker
        {
            Home,
            Entertainment,
            Food,
            Charity,
            Utilities,
            Auto,
            Education,
            HelathAndWellness,
            Shopping
        };

        public bool CanNotify { get; set; }

        protected readonly INavigationService NavigationService;

        public List<MasterPageItem> MasterPageItems { get; set; }

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (_selectedItem != null)
                    NavigationService.InternalNavigateToPage(_selectedItem as MasterPageItem);
                NotifyPropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Gets or sets DataSource to group the trasactions to be display in SfListView
        /// </summary>
        public DataSource GroupingDataSource { get; set; }

        /// <summary>
        /// Gets or sets the Cutsom palette for PieSeries
        /// </summary>
        public List<Color> CategoryColors { get; set; }

        /// <summary>
        /// Gets or sets total amount spent 
        /// </summary>
        public double Spent
        {
            get { return _spent; }
            set
            {
                _spent = value;
                NotifyPropertyChanged("Spent");
            }
        }

        /// <summary>
        /// Gets or sets total remaining amount
        /// </summary>
        public double Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                NotifyPropertyChanged("Balance");
            }
        }

        /// <summary>
        /// Gets or sets selected category like auto, charity etc.
        /// </summary>
        public ExpenseCategory SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyPropertyChanged("SelectedCategory");
                if (_selectedCategory != null)
                    NavigationService.InternalNavigateToPage(this);
            }
        }

        /// <summary>
        /// Gets or sets transactions details of an selected category
        /// </summary>
        public IEnumerable SelectedCategoryTransactions
        {
            get { return Transactions.Where(i => i.Category == SelectedCategory.Name).ToList(); }
        }

        /// <summary>
        /// Gets or sets transactions details for selected month
        /// </summary>
        public IEnumerable SelectedTrends
        {
            get { return _selectedTrends; }

            set
            {
                _selectedTrends = value;
                NotifyPropertyChanged("SelectedTrends");
            }
        }

        /// <summary>
        /// Gets or sets the overall transaction details 
        /// </summary>
        public ObservableCollection<TransactionDetail> Transactions => _transactions ?? (_transactions = App.DataService.GetTransactions());

        public AddTransactionDetail SingleTransaction { get; set; }

        /// <summary>
        /// Gets or sets the overall transaction and category details
        /// </summary>
        public ObservableCollection<ExpenseCategory> Categories
        {
            get
            {
                if (_categories == null)
                    _categories = App.DataService.GetCategories();
                var totalSpentOnCategory = Transactions.GroupBy(i => i.Category)
                    .Select(g => new {Category = g.Key, Value = g.Sum(i => i.Spent)}).ToList();

                for (var i = 0; i < _categories.Count; i++)
                {
                    _categories[i].Balance = _categories[i].Budget - totalSpentOnCategory[i].Value;
                    _categories[i].Percentage = totalSpentOnCategory[i].Value/_categories[i].Budget*100;
                    _categories[i].Spent = totalSpentOnCategory[i].Value;
                    _categories[i].Transactions = Transactions.Where(j => j.Category == _categories[i].Name).ToList();
                }

                Spent = 0;
                Balance = 0;

                foreach (var expense in _categories)
                {
                    Spent += expense.Spent;
                    Balance += expense.Balance;
                }

                return _categories;
            }
        }

        public ICommand AddNewData { get; set; }

        public ICommand AutoGeneratingColumns { get; set; }

        public ICommand AddNewTransaction { get; set; }
        
        public void AddNewTransactionClicked()
        {
            SingleTransaction = new AddTransactionDetail { Date = new DateTime(2018, 03, 01) };
            NavigationService.InternalNavigateToAddTransactionsPage(this);
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
                    NavigationService.NavigatePopToRoot(this);
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
                    NavigationService.NavigatePopToRoot(this);
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

        public ExpenseViewModel()
        {
            NavigationService = new NavigationService();
            AddNewData = new Command(execute: AddNewTransactions);
            AddNewTransaction = new Command(execute: AddNewTransactionClicked);
            AutoGeneratingColumns = new Command(execute: AutoGenerateColumns);
            UpdateTrends(2);
            GroupingDataSource = new DataSource();
            GroupingDataSource.GroupDescriptors.Add(new GroupDescriptor {PropertyName = "Category"});
            GroupingDataSource.SortDescriptors.Add(new SortDescriptor
            {
                PropertyName = "Date",
                Direction = ListSortDirection.Descending
            });
            CategoryColors = new List<Color>
            {
                Color.FromHex("#EA8F00"),
                Color.FromHex("#29ABE2"),
                Color.FromHex("#9f94ed"),
                Color.FromHex("#eec456"),
                Color.FromHex("#6aaaea"),
                Color.FromHex("#f06386"),
                Color.FromHex("#12ccc7"),
                Color.FromHex("#93278f"),
                Color.FromHex("#8cc63f"),
            };

            MasterPageItems = new List<MasterPageItem>
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
        }

        /// <summary>
        /// Sets transactions details of given month to SelectedTrends
        /// </summary>
        /// <param name="month"></param>
        public void UpdateTrends(int month)
        {
			_trendSpent = 0;
            foreach (var expense in Categories)
            {
                _trendSpent += expense.Spent;
            }
            SelectedTrends = Transactions.Where(i => i.Date.Month == month + 1).GroupBy(i => i.Category)
                .Select(
                    g =>
                        new
                        {
                            Category = g.Key,
                            Value = g.Sum(i => i.Spent),
                            Percentage = g.Sum(i => i.Spent)/ _trendSpent * 100,
                            Month = month + 1
                        }).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Inserts the newly added transaction to DataBase and Transactions
        /// </summary>
        /// <param name="transaction"></param>
        public void AddTransaction(TransactionDetail transaction)
        {
            App.DataService.InsertTansaction(transaction);

            Transactions.Add(transaction);
        }

        /// <summary>
        /// Groups the DataSource based on given property
        /// </summary>
        /// <param name="propertyName"></param>
        public void GroupBy(string propertyName)
        {
            GroupingDataSource.GroupDescriptors.Clear();
            GroupingDataSource.GroupDescriptors.Add(new GroupDescriptor {PropertyName = propertyName});
            GroupingDataSource.SortDescriptors.Clear();
            GroupingDataSource.SortDescriptors.Add(new SortDescriptor
            {
                PropertyName = "Date",
                Direction = ListSortDirection.Descending,
            });
        }
    }
}