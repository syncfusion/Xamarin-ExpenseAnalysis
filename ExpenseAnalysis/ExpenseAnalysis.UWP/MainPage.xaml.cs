using Syncfusion.ListView.XForms.UWP;
using Syncfusion.SfChart.XForms.UWP;
using Syncfusion.SfDataGrid.XForms.UWP;
using Syncfusion.XForms.UWP.DataForm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ExpenseAnalysis.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            SfDataGridRenderer.Init();
            SfListViewRenderer.Init();
            SfDataFormRenderer.Init();
            SfChartRenderer.Init();
            LoadApplication(new ExpenseAnalysis.App());
        }
    }
}
