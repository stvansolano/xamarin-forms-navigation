using System;
using SQLite;
using System.Linq;
using System.Diagnostics;

namespace EjemplosNavegacion
{
	public class ContextoDatos
	{
		public string RutaConexion { get; set; }

		public ContextoDatos()
		{
		}

		public void Configurar()
		{
			using (var conexion = new SQLiteConnection(RutaConexion)) 
			{
				conexion.DropTable<Pais>();
				conexion.CreateTable<Pais>();

				var tabla = conexion.Table<Pais>();

				conexion.Insert(new Pais { Name = "Costa Rica" });

				var resultado = tabla.ToArray();

				foreach (var item in resultado)
				{
					Debug.WriteLine(item.Name);
				}
			}
		}
}
}
