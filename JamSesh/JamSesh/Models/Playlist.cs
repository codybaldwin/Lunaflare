using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JamSesh69.Models
{
    [Table("Playlists")]
    public class Playlist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public List<Song> Songs { get; set; }

        public Playlist()
        {
            Songs = new List<Song>();
        }
    }
}