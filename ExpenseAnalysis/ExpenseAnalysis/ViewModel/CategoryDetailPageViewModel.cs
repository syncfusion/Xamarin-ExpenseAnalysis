using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAnalysis
{
    public class CategoryDetailPageViewModel : ExpenseViewModelBase
    {

        private IEnumerable _selectedCategoryTransactions;

        /// <summary>
        /// Gets or sets transactions details of an selected category
        /// </summary>
        public IEnumerable SelectedCategoryTransactions
        {
            get { return _selectedCategoryTransactions; }
            set
            {
                _selectedCategoryTransactions = value;
                NotifyPropertyChanged("SelectedCategoryTransactions");
            }
        }

        public string Title
        {
            get
            {
                if (SelectedCategoryTransactions != null)
                {
                    foreach (var transaction in SelectedCategoryTransactions)
                    {
                        return (transaction as TransactionDetail).Category;
                    }
                }

                return "";
            }
        }
    }
}
