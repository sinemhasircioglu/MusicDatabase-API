using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDatabase.API.Data.Entities
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public int StartedYear { get; set; }
        public bool IsGroup { get; set; }
        public string Country { get; set; }


        [JsonIgnore]
        public virtual List<Album> Albums { get; set; }
        [JsonIgnore]
        public virtual List<Song> Songs { get; set; }
        [JsonIgnore]
        public virtual List<Featuring> Featurings { get; set; }
    }
}
