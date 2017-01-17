using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EjemplosNavegacion
{
	public class RepositorioPaises
	{
		private ClienteRest _cliente;

		public ContextoDatos Contexto { get; private set; }

		public RepositorioPaises()
		{
			Contexto = DependencyService.Get<ContextoDatos>(DependencyFetchTarget.GlobalInstance);

			_cliente = new ClienteRest();
		}

		public void Guardar(params Pais[] coleccion)
		{
			Contexto.Guardar(coleccion);
		}

		public async Task<IEnumerable<Pais>> Obtener() 
		{
			var resultado = await _cliente.GetPaises();

			if (resultado.Any() == false)
			{
				resultado = Contexto.Obtener<Pais>();

				foreach (var item in resultado)
				{
					item.Bandera = new Uri(string.Format("http://www.geognos.com/api/en/countries/flag/{0}.png", item.Alpha2Code));
				}

				return resultado;
			}

			foreach (var item in resultado)
			{
				item.Bandera = new Uri(string.Format("http://www.geognos.com/api/en/countries/flag/{0}.png", item.Alpha2Code));
			}

			return resultado;
		}
	}
}