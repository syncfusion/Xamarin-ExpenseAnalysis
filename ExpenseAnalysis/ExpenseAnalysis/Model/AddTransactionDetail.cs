using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAnalysis
{
    public class AddTransactionDetail
    {
        public double Spent { get; set; }

        public CategoryPicker Category { get; set; }

        [Display(Name = "Expense Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description should not be empty")]
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
