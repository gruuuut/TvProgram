using System.Collections.Generic;

namespace TvProgram.Entities
{
	public class Film : Media
	{
		public List<Realisateur> Realisateurs { get; set; }

		public int AnneeSortie { get; set; }

		public string TypeFilm { get; set; }
	}
}
