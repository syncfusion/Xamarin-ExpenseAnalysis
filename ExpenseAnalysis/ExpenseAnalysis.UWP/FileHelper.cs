
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(ExpenseAnalysis.UWP.FileHelper))]
namespace ExpenseAnalysis.UWP
{
    public class FileHelper : IFileHelper
    {

        SQLite.SQLiteConnection IFileHelper.DbConnection()
        {
            var dbName = "db_sqlnet.db";
            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dbName);
            return new SQLite.SQLiteConnection(path);
        }
    }
}
