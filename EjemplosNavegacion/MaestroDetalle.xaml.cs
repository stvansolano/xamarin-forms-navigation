using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EjemplosNavegacion
{
	public partial class MaestroDetalle : MasterDetailPage
	{
		public MaestroDetalle()
		{
			InitializeComponent();

			Detail = new NavigationPage(new PaginaInicial());

			Opcion1.Clicked += (sender, e) => { 
				Detail = new NavigationPage(new PaginaInicial());
				IsPresented = false;
			};

			Opcion2.Clicked += (sender, e) =>
			{
				Detail = new NavigationPage(new PaginaTabs());
				IsPresented = false;
			};
		}
	}
}
