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
			var tabla = Conexion.CreateTable<Pais>();

			Conexion.Insert(new Pais { Name = "Costa Rica" });

		}
	}
}
