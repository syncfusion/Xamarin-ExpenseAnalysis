using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class NavigationService : INavigationService
    {
        protected Page CurrentDetail
        {
            get { return (Application.Current.MainPage as MasterDetail).Detail; }
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("ViewModel", string.Empty);

            if (Device.RuntimePlatform == Device.macOS && viewModelType.Name == "AddTransactionsPageViewModel")
                viewName = viewModelType.FullName.Replace("ViewModel", "_MacOS");

            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        public void NavigateToPage(MasterPageItem item)
        {
            NavigationPage page = new NavigationPage((Page)Activator.CreateInstance((item as MasterPageItem).TargetType));

            if (Device.RuntimePlatform != Device.macOS)
            {
                page.BarBackgroundColor = Color.FromHex("#3F539F");
                page.BarTextColor = Color.White;
            }
            (Application.Current.MainPage as MasterDetail).Detail = page;

            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                (Application.Current.MainPage as MasterDetail).IsPresented = false;

        }

        public void NavigateToPage(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType);

            if (page is AddTransactionsPage || page is AddTransactionsPage_MacOS)
                (page.BindingContext as AddTransactionsPageViewModel).Transactions =
                    (parameter as ObservableCollection<TransactionDetail>);
            else if (page is CategoryDetailPage)
                (page.BindingContext as CategoryDetailPageViewModel).SelectedCategoryTransactions = parameter as IEnumerable;

            CurrentDetail.Navigation.PushAsync(page);
        }

        public void NavigatePopToRoot()
        {
            CurrentDetail.Navigation.PopAsync();
        }
    }
}