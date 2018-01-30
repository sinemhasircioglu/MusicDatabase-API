using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDatabase.API.Data.Entities
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
        public string  Barcode { get; set; }
        public bool IsSingle { get; set; }
        public string Country { get; set; }


        [JsonIgnore]
        public virtual Artist Artist { get; set; }
        [JsonIgnore]
        public virtual  List<Song> Songs { get; set; }


    }
}
