using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EjemplosNavegacion
{
	public partial class App : Application
	{
		public ContextoDatos Contexto { get; set; }

		public App()
		{
			InitializeComponent();

			DependencyService.Register<ContextoDatos>();

			Contexto = DependencyService.Get<ContextoDatos>(DependencyFetchTarget.GlobalInstance);

			DependencyService.Register<RepositorioPaises>();

			MainPage = new MaestroDetalle();
		}

		protected override void OnStart()
		{
			Contexto.Configurar<Pais>();
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
