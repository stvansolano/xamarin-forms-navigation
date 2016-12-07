using System;
using SQLite;

namespace EjemplosNavegacion
{
	public class ContextoDatos
	{
		public string CadenaConexion { get; set; }
		private SQLiteConnection _conexion;
		protected SQLiteConnection Conexion { 
			get 
			{
				if (_conexion == null)
				{
					_conexion = new SQLiteConnection(CadenaConexion);
				}
				return _conexion;
			}
		}

		public void Configurar() 
		{
			Conexion.CreateTable<Pais>();

			var tabla = Conexion.Table<Pais>();

			Conexion.Insert(new Pais { Name = "Costa Rica" });

		}
	}
}
