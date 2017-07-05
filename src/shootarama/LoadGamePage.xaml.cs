using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace shootarama
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadGamePage : ContentPage
	{
		public LoadGamePage ()
		{
			InitializeComponent ();

	        NavigationPage.SetHasNavigationBar(this, false);
	    }

	    private async void btnBack_Click(object sender, EventArgs e)
	    {
	        await Navigation.PopAsync(true);
	    }
    }
}