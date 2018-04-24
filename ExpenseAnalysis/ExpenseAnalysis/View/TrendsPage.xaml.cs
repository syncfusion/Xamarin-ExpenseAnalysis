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

        protected override void OnSizeAllocated(double width, double height)
        {
            if ((width > height) && Device.Idiom == TargetIdiom.Phone)
            {
                Grid.SetRowSpan(columnChart, 2);
                Grid.SetColumnSpan(columnChart, 1);

                Grid.SetRowSpan(pieChart, 2);
                Grid.SetColumnSpan(pieChart, 1);
                Grid.SetRow(pieChart, 0);
                Grid.SetColumn(pieChart, 1);

                columnChart.Margin = new Thickness(5,20,5,20);
                pieChart.Margin = 15;
                (pieChart.Series[0] as PieSeries).CircularCoefficient = 0.6;
            }
            else
            {
                Grid.SetColumnSpan(columnChart, 2);
                Grid.SetRowSpan(columnChart, 1);
            
                Grid.SetColumnSpan(pieChart, 2);
                Grid.SetRowSpan(pieChart, 1);
                Grid.SetRow(pieChart, 1);
                Grid.SetColumn(pieChart, 0);

                columnChart.Margin = new Thickness(5,15,5,5);
                pieChart.Margin = 5;
                (pieChart.Series[0] as PieSeries).CircularCoefficient = 0.8;
            }
            base.OnSizeAllocated(width, height);
        }
    }
}
