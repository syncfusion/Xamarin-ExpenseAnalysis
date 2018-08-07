using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public interface INavigationService
    {
       void NavigateToPage(MasterPageItem item);

        void NavigateToPage(Type item, object parameter);

        void NavigatePopToRoot();
    }
}