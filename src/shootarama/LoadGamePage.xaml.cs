using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using shootarama.ViewModels;

namespace shootarama
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadGamePage : ContentPage
	{
	    private LoadGameVM viewModel => (LoadGameVM) BindingContext;

		public LoadGamePage ()
		{
			InitializeComponent ();

		    BindingContext = new LoadGameVM();

	        NavigationPage.SetHasNavigationBar(this, false);

		    viewModel.LoadData();
		}

	    private async void btnBack_Click(object sender, EventArgs e)
	    {
	        await Navigation.PopAsync(true);
	    }
    }
}