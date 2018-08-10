using Syncfusion.XForms.DataForm;
using System;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public partial class AddTransactionsPage
    {
        public AddTransactionsPage()
        {
            InitializeComponent();
			
			if (Device.RuntimePlatform == Device.UWP)
				dataForm.HorizontalOptions = LayoutOptions.Start;
        }
    }
}