using System;
using AppKit;
using CoreGraphics;
using ExpenseAnalysis.MacOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(DatePicker), typeof(CustomDatePickerRenderer))]
namespace ExpenseAnalysis.MacOS.Renderer
{
	public class CustomDatePickerRenderer : DatePickerRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
				Control.Alignment = NSTextAlignment.Right;
			Control.DatePickerStyle = NSDatePickerStyle.TextFieldAndStepper;
		}
	}
}
