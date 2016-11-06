using System;
using Xamarin.Forms;

namespace EjemplosNavegacion
{
	public partial class PaginaInicial : ContentPage
	{
		public PaginaInicial()
		{
			InitializeComponent();

			BtnAccion.Clicked += OnClicked;

			PickerNavegacion.Items.Add("Inicio");
			PickerNavegacion.Items.Add("Tabs");

			PickerNavegacion.SelectedIndex = 0;
		}

		private async void OnClicked(object sender, EventArgs e)
		{
			/*
			var navigationPage = new NavigationPage(new PaginaInicial());
			navigationPage.Title = "Titulo" + Navigation.ModalStack.Count;
			navigationPage.CurrentPage.Title = navigationPage.Title;

			await Navigation.PushModalAsync(navigationPage);
			*/
			Page pagina = null;

			if (PickerNavegacion.SelectedIndex == 0)
			{
				pagina = new PaginaInicial();
			}
			else if (PickerNavegacion.SelectedIndex == 1)
			{
				pagina = new PaginaTabs();
			}

			// Navegar
			if (pagina != null)
			{
				pagina.Title = "Nivel:" + Navigation.NavigationStack.Count;

				await Navigation.PushAsync(pagina);
			}
		}
	}
}
