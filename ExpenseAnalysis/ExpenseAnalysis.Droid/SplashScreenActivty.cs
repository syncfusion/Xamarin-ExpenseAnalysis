#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ExpenseAnalysis.Droid;

namespace ExpenseAnalysis.Droid
{
    [Activity(Theme = "@style/Theme.Splash", //Indicates the theme to use for this activity
            MainLauncher = true, //Set it as boot activity
            NoHistory = true, Label = "Expense Analysis", Icon = "@drawable/icon")]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.StartActivity(typeof(MainActivity));
        }
    }
}