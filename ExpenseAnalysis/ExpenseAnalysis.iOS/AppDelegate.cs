using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Syncfusion.SfDataGrid.XForms.iOS;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using Syncfusion.SfNumericTextBox.XForms.iOS;
using Syncfusion.XForms.iOS.DataForm;

namespace ExpenseAnalysis.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			SfDataGridRenderer.Init();
			SfListViewRenderer.Init();
            SfChartRenderer.Init();
            SfNumericTextBoxRenderer.Init();
            SfDataFormRenderer.Init();
            UITabBarItem.Appearance.TitlePositionAdjustment = new UIOffset(0, -10);
			UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes() { TextColor = UIColor.White, Font = UIFont.BoldSystemFontOfSize(16)}, UIControlState.Normal);

			UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes() { TextColor = UIColor.Green, Font = UIFont.BoldSystemFontOfSize(16) }, UIControlState.Selected);
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
