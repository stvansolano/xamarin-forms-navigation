
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EjemplosNavegacion
{
	public partial class ListadoDatos : ContentPage
	{
		public ObservableCollection<Pais> Items { get; set; }
		private RepositorioPaises _repositorio;

		public ListadoDatos()
		{
			Items = new ObservableCollection<Pais>();
			InitializeComponent();

			_repositorio = DependencyService.Get<RepositorioPaises>(DependencyFetchTarget.GlobalInstance);

			Lista.ItemTapped += LvDatos_ItemTapped;
			Lista.Refreshing += LvDatos_Refreshing;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			CargarDatos();
		}

		public async void CargarDatos()
		{
			IsBusy = true;
			Items.Clear();

			var resultado = await _repositorio.Obtener();

			LlenarPaises(resultado.ToArray());
		}

		private void LlenarPaises(Pais[] resultado)
		{
			foreach (var item in resultado)
			{
				Items.Add(item);
			}	

			IsBusy = false;
		}

		private void LvDatos_Refreshing(object sender, EventArgs e)
		{
			CargarDatos();
			IsBusy = false;
		}

		private void LvDatos_ItemTapped(object sender, ItemTappedEventArgs e)
		{
		}
	}
}