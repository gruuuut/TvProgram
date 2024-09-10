using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TvProgram.Entities;
using TvProgram.Utils;
using static System.Windows.Forms.LinkLabel;

namespace TvProgram.Service
{
    public class FileService
    {
        /// <summary>
        /// Récupère une liste d'objet Favori à partir du chemin du fichier contenant tous les sous-éléments du répertoire "Films déjà statués"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Favori> LireFichierFavori(string path)
        {
            
            var result = new List<Favori>();
            StreamReader sr = new StreamReader(path);
            var line = sr.ReadLine();
            var favori = new Favori();
            favori.UrlFavori = GetFieldValue(line, "HREF");
            favori.DateAjoutFavori = GetDate(line);
            favori.LibelleFavori = GetLibelle(line);
            if (!string.IsNullOrEmpty(favori.UrlFavori) && favori.UrlFavori.Contains("https://www.programme-tv.net/cinema/"))
            {
                result.Add(favori);
            }            

            while (line != null)
            {                
                line = sr.ReadLine();

                favori = new Favori();
                favori.UrlFavori = GetFieldValue(line, "HREF");
                favori.DateAjoutFavori = GetDate(line);
                favori.LibelleFavori = GetLibelle(line);
                if (!string.IsNullOrEmpty(favori.UrlFavori) && favori.UrlFavori.Contains("https://www.programme-tv.net/cinema/"))
                {
                    result.Add(favori);
                }                    
            }
            sr.Close();
            Console.ReadLine();

            return result;
        }

        /// <summary>
        /// Récupère la date dans la chaîne <A>...</A>
        /// 
        /// TODO améliorer l'algo (ou au moins avoir des variables plus explicites)
        /// </summary>
        /// <param name="ligne"></param>
        /// <returns></returns>
        public DateTime? GetDate(string ligne)
        {
            string result = GetFieldValue(ligne, "ADD_DATE");

            if (result != null)
            {                
                return DateUtils.ToDateTime(result.ToString());
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Récupère le libellé dans la chaîne <A>...</A>
        /// </summary>
        /// <param name="ligne"></param>
        /// <returns></returns>
        public string GetLibelle(string ligne)
        {
            string field = "ICON";

            if (ligne != null && ligne.Trim() != "")
            {                
                int posDebut = ligne.IndexOf($"{field}", 0);
                if (posDebut == -1)
                {
                    field = "ADD_DATE";
                    posDebut = ligne.IndexOf($"{field}", 0);
                }
                int i = 1;
                int fieldLength = field.Length;
                if (ligne.Substring(posDebut + fieldLength, 1) == "=" && ligne.Substring(posDebut + fieldLength + 1, 1) == "\"")
                {
                    // Récupération de la chaîne comprise entre les double quotes
                    while (ligne.Substring(posDebut + fieldLength + 1 + i, 1) != "\"")
                    {                        
                        i++;
                    }
                }
                int posFin = i;
                int posDebutBaliseA = ligne.IndexOf(@"</A>", 0);

                return ligne.Substring(posDebut + posFin + fieldLength + 3, posDebutBaliseA - (posDebut + posFin + fieldLength + 3)).Trim();
            }
            else
            {
                return null;
            }
        }

        public string GetFieldValue(string entry, string field)
        {
            int fieldLength = field.Length;

            if (entry != null && entry.Trim() != "")
            {
                var result = new StringBuilder();
                int pos = entry.IndexOf($"{field}=\"", 0, StringComparison.OrdinalIgnoreCase);
                int i = 1;
                if (entry.Substring(pos + fieldLength, 1) == "=" && entry.Substring(pos + fieldLength + 1, 1) == "\"")
                {
                    // Récupération de la chaîne comprise entre les double quotes
                    while (entry.Substring(pos + fieldLength + 1 + i, 1) != "\"")
                    {
                        result.Append(entry.Substring(pos + fieldLength + 1 + i, 1));
                        i++;
                    }
                }
                return result.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
