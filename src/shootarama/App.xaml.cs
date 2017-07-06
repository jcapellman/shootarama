using shootarama.Controllers;
using shootarama.Enums;

using Xamarin.Forms;

namespace shootarama
{
	public partial class App : Application
	{
	    public static MessageController MController { get; private set; }

        public App ()
		{
			InitializeComponent();
            
		    MController = new MessageController();

		    MController.AddMessageAsync(MessageType.SQLITE_INITIALIZE, null);

			MainPage = new NavigationPage(new MainPage());
		}
	}
}