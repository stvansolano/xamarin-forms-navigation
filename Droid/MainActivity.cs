using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace EjemplosNavegacion.Droid
{
	[Activity(Label = "EjemplosNavegacion.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			var app = new App();

			app.Contexto.RutaConexion = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			app.Contexto.RutaConexion +=  "/paises.db3";

			LoadApplication(app);
		}
	}
}
