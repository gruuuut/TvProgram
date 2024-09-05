using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using TvProgram.Entities;

namespace TvProgram.Sqlite
{
    public class FilmRepository
    {
        public bool AjouterFilms(List<Favori> favoris)
        {
            try
            {
                var connection = new SqliteConnection("Data Source=C:\\Yoann\\Projets\\YBL\\TvProgram\\TvProgram\\TvProgram.db");
                connection.Open();

                var sql = "INSERT INTO Film (url, libelle, date_favori) " +
                            "VALUES (@url, @libelle, @date_favori)";

                int index = 1;

                foreach (var favori in favoris)
                {
                    var command = new SqliteCommand(sql, connection);

                    command.Parameters.AddWithValue("@url", favori.UrlFavori);
                    command.Parameters.AddWithValue("@libelle", favori.LibelleFavori);
                    command.Parameters.AddWithValue("@date_favori", favori.DateAjoutFavori);
                    command.ExecuteNonQuery();
                    index++;
                }

                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }            
        }
    }
}
