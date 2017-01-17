using SQLite;
using System.Linq;
using System;

namespace EjemplosNavegacion
{
	public class ContextoDatos
	{
		public string RutaConexion { get; set; }

		internal void Guardar<TipoGenerico>(TipoGenerico[] coleccion)
			where TipoGenerico : class,
				new()
		{
			using (var conexion = NuevaConexion())
			{
				conexion.BeginTransaction();

				foreach (var item in coleccion)
				{
					conexion.Insert(item);
				}

				conexion.Commit();
			}
		}

		internal void Configurar<TipoGenerico>()
			where TipoGenerico : class,
				new() // Debe tener un constructor por defecto
		{
			using (var conexion = NuevaConexion())
			{
				conexion.CreateTable<TipoGenerico>();
			}
		}

		private SQLiteConnection NuevaConexion()
		{
			return new SQLiteConnection(RutaConexion);
		}

		public TipoGenerico[] Obtener<TipoGenerico>()
			where TipoGenerico : class,
				new() // Debe tener un constructor por defecto
		{
			using (var conexion = NuevaConexion())
			{
				var tabla = conexion.Table<TipoGenerico>();

				return conexion.Table<TipoGenerico>().ToArray();
			}
		}
	}
}