using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDatabase.API.Data.Entities
{
    public class Lyric
    {
        [Key]
        public int Id { get; set; }
        public string LyricText { get; set; }
        public int SongId { get; set; }
        public string Language { get; set; }

        [JsonIgnore]
        public virtual Song Song { get; set; }
    }
}
