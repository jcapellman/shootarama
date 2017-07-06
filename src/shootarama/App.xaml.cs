using shootarama.DB;

using Xamarin.Forms;

namespace shootarama
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    using (var db = new DBManager())
		    {
		        db.Initialize();
		    }

			MainPage = new NavigationPage(new MainPage());
		}
	}
}