using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TvProgram.Entities;

namespace TvProgram.Services
{
    public class TeleLoisirsService
	{
		public List<Film> GetFilms(DateTime date, List<Chaine> chainesDetaillees)
		{

			return new List<Film>();
		}

		public string GetCodeSource(DateTime date, List<Chaine> chainesDetaillees)
		{
			string result;
			var urlSuffixeDate = date.Year == DateTime.Now.Year && date.Month == DateTime.Now.Month && date.Day == DateTime.Now.Day
				? ""
				: date.ToString("yyyy-MM-dd");
			var url = "https://www.programme-tv.net/programme/numericable-7/" + urlSuffixeDate;


			HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
			myRequest.Method = "GET";
			myRequest.CookieContainer = new CookieContainer();
			WebResponse myResponse = myRequest.GetResponse();
			StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
			result = sr.ReadToEnd();
			sr.Close();
			myResponse.Close();

			return result;
		}

		public List<Film> GetUrlFilms(string codeSourceComplet)
		{
			List<Film> result = new List<Film>();
			int tailleCodeSource = codeSourceComplet.Length;

			int posDebut = codeSourceComplet.IndexOf("https://www.programme-tv.net/cinema/");
			int posFinFilmPrecedent = 0;
			string anchor = null;

			while (posDebut < tailleCodeSource - 100 && !string.IsNullOrEmpty(anchor) || result.Count == 0)
			{
				anchor = GetNextAnchor(codeSourceComplet, ref posFinFilmPrecedent);

				if (CheckAnchor(anchor))
				{
					var url2 = GetAttributeFromAnchor(anchor, "href");
					var nomFilm = GetAttributeFromAnchor(anchor, "title");
					var film = new Film();
					film.Url = url2;
					film.Nom = nomFilm;

					if (CheckUrl(url2))
                    {
						result.Add(film);
					}
				}
				posDebut = posFinFilmPrecedent;
			}

			return result;
		}

		public string GetNextUrl(string codeSource, ref int posFinFilmPrecedent)
		{
			int posDebut = codeSource.IndexOf("https://www.programme-tv.net/cinema/", posFinFilmPrecedent + 1);
			string result = "";
			if (posDebut > 0) // signifie qu'une occurrence a été trouvée (sinon, la valeur est -1 et donc plantage au dernier SubString de la méthode)
			{
				int i = 0;
				int posFin = posDebut + 1;
				while (codeSource.Substring(posFin, 1) != " ")
				{
					posFin++;
					i++;
				}

				posFinFilmPrecedent = posFin;
				result = codeSource.Substring(posDebut, i);
			}
			return result;
		}

		public string GetNextAnchor(string codeSource, ref int posFinAnchorPrecedente)
		{
			int posDebut = codeSource.IndexOf(@"<a href=""https://www.programme-tv.net/cinema/", posFinAnchorPrecedente + 1);
			string result = "";
			if (posDebut > 0) // signifie qu'une occurrence a été trouvée (sinon, la valeur est -1 et donc plantage au dernier SubString de la méthode)
			{
				int i = 0;
				int posFin = posDebut + 1;
				while (codeSource.Substring(posFin, 4) != "</a>")
				{
					posFin++;
					i++;
				}

				posFinAnchorPrecedente = posFin;
				result = codeSource.Substring(posDebut, i + 5);
			}
			return result;
		}

		private bool CheckUrl(string url)
		{
			bool result;
			if (url.Length > 36)
			{
				result = char.IsNumber(url[36]);
			}
			else
			{
				result = false;
			}

			return result;
		}

		private bool CheckAnchor(string anchor)
        {
			bool result;
			if (anchor.Length > 6)
            {
				result = anchor.Substring(0, 2) == "<a" && anchor.Substring(anchor.Length - 4, 4) == "</a>";
            }
			else
            {
				result = false;
            }
			return result;
        }

		private string GetAttributeFromAnchor(string anchor, string attribute)
        {
			string result = "";
			if (CheckAnchor(anchor))
            {
				var posHRef = anchor.IndexOf($"{attribute}");
				if (posHRef > 0)
                {
					int i = 0;
					int posFin = posHRef + 1;
					while (anchor.Substring(posFin, 2) != @""" ")
					{
						posFin++;
						i++;
					}

					result = anchor.Substring(posHRef + attribute.Length + 2, i - attribute.Length - 1); // car on part après le nom de l'attribut puis le = puis le "
				}
			}
			return result;
        }
	}
}
