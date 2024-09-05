using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TvProgram.Entities;
using TvProgram.Utils;

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
            favori.UrlFavori = GetUrl(line);
            favori.DateAjoutFavori = GetDate(line);
            favori.LibelleFavori = GetLibelle(line);
            if (!string.IsNullOrEmpty(favori.UrlFavori))
            {
                result.Add(favori);
            }            

            while (line != null)
            {                
                line = sr.ReadLine();

                favori = new Favori();
                favori.UrlFavori = GetUrl(line);
                favori.DateAjoutFavori = GetDate(line);
                favori.LibelleFavori = GetLibelle(line);
                if (!string.IsNullOrEmpty(favori.UrlFavori))
                {
                    result.Add(favori);
                }                    
            }
            sr.Close();
            Console.ReadLine();

            return result;
        }

        /// <summary>
        /// Récupère l'URL dans la chaîne <A>...</A>
        /// 
        /// TODO améliorer l'algo (ou au moins avoir des variables plus explicites)
        /// </summary>
        /// <param name="ligne"></param>
        /// <returns></returns>
        public string GetUrl(string ligne)
        {
            if (ligne != null && ligne.Trim() != "")
            {
                var result = new StringBuilder();
                int posHREF = ligne.IndexOf(@"HREF=""https://www.programme-tv.net/cinema/", 0);
                int i = 1;
                if (ligne.Substring(posHREF + 4, 1) == "=" && ligne.Substring(posHREF + 5, 1) == "\"")
                {
                    // Récupération de la chaîne comprise entre les double quotes
                    while (ligne.Substring(posHREF + 5 + i, 1) != "\"")
                    {
                        result.Append(ligne.Substring(posHREF + 5 + i, 1));
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

        /// <summary>
        /// Récupère la date dans la chaîne <A>...</A>
        /// 
        /// TODO améliorer l'algo (ou au moins avoir des variables plus explicites)
        /// </summary>
        /// <param name="ligne"></param>
        /// <returns></returns>
        public DateTime? GetDate(string ligne)
        {
            if (ligne != null && ligne.Trim() != "")
            {
                var date = new StringBuilder();
                int posADD_DATE = ligne.IndexOf(@"ADD_DATE");
                int i = 1;
                if (ligne.Substring(posADD_DATE + 8, 1) == "=" && ligne.Substring(posADD_DATE + 9, 1) == "\"")
                {
                    // Récupération de la chaîne comprise entre les double quotes
                    while (ligne.Substring(posADD_DATE + 9 + i, 1) != "\"")
                    {
                        date.Append(ligne.Substring(posADD_DATE + 9 + i, 1));
                        i++;
                    }
                }
                return DateUtils.ToDateTime(date.ToString());
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
            if (ligne != null && ligne.Trim() != "")
            {
                int posDebutICON = ligne.IndexOf(@"ICON", 0);
                int i = 1;
                if (ligne.Substring(posDebutICON + 4, 1) == "=" && ligne.Substring(posDebutICON + 5, 1) == "\"")
                {
                    // Récupération de la chaîne comprise entre les double quotes
                    while (ligne.Substring(posDebutICON + 5 + i, 1) != "\"")
                    {                        
                        i++;
                    }
                }
                int posFinICON = i;
                int posDebutBaliseA = ligne.IndexOf(@"</A>", 0);

                return ligne.Substring(posDebutICON + posFinICON + 7, posDebutBaliseA - (posDebutICON + posFinICON + 7)).Trim();
            }
            else
            {
                return null;
            }
        }
    }
}
