using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDatabase.API.Data.Entities
{
    public class Featuring
    {
        [Key]
        public int Id { get; set; }
        public int SongId { get; set; }
        public int ArtistId { get; set; }


        [JsonIgnore]
        public virtual Song Song { get; set; }
        [JsonIgnore]
        public virtual Artist Artist { get; set; }

    }
}
