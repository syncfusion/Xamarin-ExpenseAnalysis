﻿using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(ExpenseAnalysis.iOS.CustomNavigationPageRenderer))]



namespace ExpenseAnalysis.iOS
{
	public class CustomNavigationPageRenderer : NavigationRenderer
	{
		public CustomNavigationPageRenderer()
		{
			//App.NavigationBarHeight = (int)NavigationBar.Frame.Height;
			NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
			NavigationBar.ShadowImage = new UIImage();
		}
	}

}
