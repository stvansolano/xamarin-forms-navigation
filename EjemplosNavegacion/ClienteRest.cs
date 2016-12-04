using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EjemplosNavegacion
{
	public class ClienteRest
	{
		public async Task<IEnumerable<Pais>> GetPaises() 
		{
			using (var httpClient = new HttpClient()) 
			{
				httpClient.BaseAddress = new Uri("https://restcountries.eu/");

				var respuesta = await httpClient.GetAsync("rest/v1/all");

				if (respuesta.IsSuccessStatusCode)
				{
					var json = await respuesta.Content.ReadAsStringAsync();

					return JsonConvert.DeserializeObject<IEnumerable<Pais>>(json);
				}

				return new Pais[0];
			};
		}


		public async Task Post(Pais pais)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri("https://restcountries.eu/");

				var jsonContent = new StringContent(JsonConvert.SerializeObject(pais), Encoding.UTF8, "application/json");

				var respuesta = await httpClient.PostAsync("rest/v1/all", jsonContent);

				if (respuesta.IsSuccessStatusCode)
				{
					//var json = await respuesta.Content.ReadAsStringAsync();

					//return JsonConvert.DeserializeObject<Pais>(json);
				}
			};
		}
	}
}
