using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDatabase.API.Data.Entities
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public string Language { get; set; }
        public bool IsFeaturing { get; set; }

        [JsonIgnore]
        public virtual Album Album { get; set; }
        [JsonIgnore]
        public virtual Artist Artist { get; set; }
        [JsonIgnore]
        public virtual Genre Genre { get; set; }
        [JsonIgnore]
        public virtual List<Featuring> Featurings { get; set; }
        [JsonIgnore]
        public virtual List<Lyric> Lyrics { get; set; }

    }
}
