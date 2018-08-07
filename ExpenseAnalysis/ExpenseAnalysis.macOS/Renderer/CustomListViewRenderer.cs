using AppKit;
using ExpenseAnalysis.MacOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(ListView), typeof(CustomListViewRenderer))]
namespace ExpenseAnalysis.MacOS.Renderer
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {            
            base.OnElementChanged(e);

            if (Control != null && Control is NSScrollView scrollView)
            {
                scrollView.HasVerticalScroller = false;
            }
        }
    }
}
