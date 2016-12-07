using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EjemplosNavegacion
{
	public partial class App : Application
	{
		public ContextoDatos Contexto { get; private set; }

		public App()
		{
			Contexto = new ContextoDatos();

			InitializeComponent();

			MainPage = new MaestroDetalle();
		}

		protected override void OnStart()
		{
			Contexto.Configurar();
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
