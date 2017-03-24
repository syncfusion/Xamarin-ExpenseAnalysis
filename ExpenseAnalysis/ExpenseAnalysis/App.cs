using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class App : Application
    {
        private static DataService _dataService;

        public App()
        {
            MainPage = new MasterDetail();
        }

        public static DataService DataService => _dataService ?? (_dataService = new DataService());
    }
}