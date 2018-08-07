using System;
using AppKit;
using CoreGraphics;
using ExpenseAnalysis.MacOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace ExpenseAnalysis.MacOS.Renderer
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.Bordered = false;
        }
    }
}
