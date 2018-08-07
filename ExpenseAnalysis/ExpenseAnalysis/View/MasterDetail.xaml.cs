using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public partial class MasterDetail
    {
        public MasterDetail()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.macOS)
                MasterBehavior = MasterBehavior.Split;
            else
            {
                navigationPage.BarBackgroundColor = Color.FromHex("#3F539F");
                navigationPage.BarTextColor = Color.White;
            }
        }
    }
}