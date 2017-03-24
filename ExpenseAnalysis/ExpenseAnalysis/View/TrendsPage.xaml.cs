using Syncfusion.SfChart.XForms;
using System;

namespace ExpenseAnalysis
{
    public partial class TrendsPage
    {
        public TrendsPage()
        {
            InitializeComponent();
            FastLineSeries.StrokeDashArray = new double[] { 20, 5 };
        }

        private void Axis_LabelCreated(object sender, ChartAxisLabelEventArgs e)
        {
            var date = DateTime.ParseExact(e.LabelContent, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            e.LabelContent = date.ToString("MMM") + "\n" + date.ToString(" yy");
        }
    }
}
