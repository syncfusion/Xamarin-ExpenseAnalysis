using SQLite;

namespace ExpenseAnalysis
{
    public interface IFileHelper
    {
        SQLiteConnection DbConnection();
    }
}