using System;
using ExpenseAnalysis.MacOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(CustomMasterDetailRenderer))]
namespace ExpenseAnalysis.MacOS.Renderer
{
    public class CustomMasterDetailRenderer : MasterDetailPageRenderer
    {
        protected override double MasterWidthPercentage => 0.2;
    }
}
