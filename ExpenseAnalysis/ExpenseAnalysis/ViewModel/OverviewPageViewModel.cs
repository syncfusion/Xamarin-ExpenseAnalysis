using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAnalysis
{
    public class OverviewPageViewModel : ExpenseViewModelBase
    {
        private double _spent;
        private double _balance;
        private ExpenseCategory _selectedCategory;

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

        public override ObservableCollection<ExpenseCategory> Categories
        {
            get
            {
                var _categories = base.Categories;

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
                    NavigationService.NavigateToPage(typeof(CategoryDetailPageViewModel),
                        Transactions.Where(i => i.Category == SelectedCategory.Name).ToList());
            }
        }
    }
}
