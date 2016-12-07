using System;
using SQLite;

namespace EjemplosNavegacion
{
	[Table("Paises")]
	public class Pais
	{
		[PrimaryKey, NotNull]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Region { get; set; }

		public string Capital { get; set; }

		[Ignore]
		public Uri Bandera { get; set; }

		public string Alpha2Code { get; set; }
	}
}
