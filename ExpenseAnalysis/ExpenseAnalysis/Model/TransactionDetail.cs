using SQLite;
using Syncfusion.XForms.DataForm;
using System;

namespace ExpenseAnalysis
{
    public class TransactionDetail
    {
        [PrimaryKey, AutoIncrement]
        [Display(AutoGenerateField = false)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public double Spent { get; set; }
        public DateTime Date { get; set; }
    }

    public class AddTransactionDetail
    {

        public double Spent { get; set; }

        public CategoryPicker Category { get; set; }

        public string ExpenseDescription { get; set; }

        public DateTime Date { get; set; }

        public enum CategoryPicker
        {
                Home,
                Entertainment,
                Food,
                Charity,
                Utilities,
                Auto,
                Education,
                HelathAndWellness,
                Shopping
        };
    }
}