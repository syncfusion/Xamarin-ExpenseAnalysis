using System;
using System.IO;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(ExpenseAnalysis.MacOS.FileHelper))]
namespace ExpenseAnalysis.MacOS
{
    public class FileHelper : IFileHelper
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "db_sqlnet.db";
            var libraryFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Library");
            var databasePath = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(databasePath);
        }
    }
}
