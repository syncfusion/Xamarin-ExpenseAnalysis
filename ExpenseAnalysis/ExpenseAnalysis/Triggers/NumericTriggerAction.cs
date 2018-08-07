using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class NumericTriggerAction : TriggerAction<Entry>
    {
        string prevText = string.Empty;

        protected override void Invoke(Entry entry)
        {
            var isNumeric = double.TryParse(entry.Text, out double value);

            if (!string.IsNullOrWhiteSpace(entry.Text) && !isNumeric)
            {
                entry.Text = prevText;
                return;
            }

            prevText = entry.Text;
        }
    }
}
