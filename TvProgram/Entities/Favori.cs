using Newtonsoft.Json;
using System;

namespace TvProgram.Entities
{
    public class Favori
    {
        [JsonProperty("IdFilm")]
        public int Id { get; set; }

        [JsonProperty("Url")]
        public string UrlFavori { get; set; }

        [JsonProperty("DateFavori")]
        public DateTime? DateAjoutFavori { get; set; }

        [JsonProperty("Libelle")]
        public string LibelleFavori { get; set; }
    }
}
