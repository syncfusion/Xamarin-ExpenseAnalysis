using System;
using AppKit;
using CoreGraphics;
using ExpenseAnalysis.MacOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(CustomMasterDetailPageRenderer))]
namespace ExpenseAnalysis.MacOS.Renderer
{
	public class CustomMasterDetailPageRenderer : MasterDetailPageRenderer
    {
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			LayoutParams p = (LayoutParams)child.LayoutParameters;
            p.Width = page.DrawerWidth;
			base.OnElementChanged(e);
		}
	}
}
