using Syncfusion.ListView.XForms;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public partial class MasterPage
    {
        public SfListView ListView => MasterDetailListView;

        public MasterPage()
        {
            InitializeComponent();
        }
    }
}