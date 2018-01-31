using Syncfusion.SfChart.XForms;
using System;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public partial class TrendsPage
    {
        public TrendsPage()
        {
            InitializeComponent();
            FastLineSeries.StrokeDashArray = new double[] { 20, 5 };
        }
    }
}
