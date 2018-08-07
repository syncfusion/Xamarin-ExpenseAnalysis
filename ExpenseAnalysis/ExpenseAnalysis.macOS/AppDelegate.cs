using AppKit;
using CoreGraphics;
using Foundation;
using Syncfusion.ListView.XForms.MacOS;
using Syncfusion.SfChart.XForms.MacOS;
using Syncfusion.SfDataGrid.XForms.MacOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace ExpenseAnalysis.MacOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow window;

        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CGRect(0, 1000, 200, 200);
            window = new NSWindow(rect, style, NSBackingStore.Buffered, false);

            rect = window.Screen.Frame;
			var width = 850;
			var height = 750;
			window.SetFrame(new CGRect(rect.Width/2-width/2, rect.Height-height, width, height), true, true);
            window.TitleVisibility = NSWindowTitleVisibility.Hidden;
        }

        public override NSWindow MainWindow
        {
            get { return window; }
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            SfListViewRenderer.Init();
            SfChartRenderer.Init();
            SfDataGridRenderer.Init();

            LoadApplication(new App());

            base.DidFinishLaunching(notification);
        }

        public override void WillTerminate(NSNotification notification)
        {
            
        }
    }
}
