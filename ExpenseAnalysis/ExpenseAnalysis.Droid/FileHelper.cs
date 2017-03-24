using System.IO;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(ExpenseAnalysis.Droid.FileHelper))]
namespace ExpenseAnalysis.Droid
{
    public class FileHelper : IFileHelper
    {
        public SQLiteConnection DbConnection()
        {
            var dbName ="db_sqlnet.db";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}