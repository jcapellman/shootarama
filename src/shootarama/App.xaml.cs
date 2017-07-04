using Xamarin.Forms;

namespace shootarama
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
		}
	}
}