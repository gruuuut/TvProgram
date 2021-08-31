using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TvProgram.Entities;

namespace TvProgram.Service
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
			HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("https://www.programme-tv.net/programme/numericable-7/");
			myRequest.Method = "GET";
			WebResponse myResponse = myRequest.GetResponse();
			StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
			result = sr.ReadToEnd();
			sr.Close();
			myResponse.Close();

			return result;
		}

		public List<string> GetUrlFilms()
		{
			List<string> result = new List<string>();
			string codeSourceComplet = GetCodeSource(DateTime.Now, new List<Chaine>());
			int tailleCodeSource = codeSourceComplet.Length;

			int posDebut = codeSourceComplet.IndexOf("https://www.programme-tv.net/cinema/");
			int posFinFilmPrecedent = 0;
			string url = null;

			while (posDebut < tailleCodeSource - 100 && !string.IsNullOrEmpty(url) || result.Count == 0)
			{
				url = GetNextUrl(codeSourceComplet, ref posFinFilmPrecedent);

				if (CheckUrl(url))
				{
					result.Add(url);
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
	}
}
