using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class App : Application
    {
        private static DataService _dataService;

        public static DataService DataService => _dataService ?? (_dataService = new DataService());

        public App()
        {
            MainPage = new MasterDetail();
        }
    }
}