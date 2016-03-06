using JamSesh.Models;
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
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public Jammer Jammer { get; set; }

        public Playlist(string name, Jammer Jammer)
        {
            Name = name;
            Jammer = Jammer;
            Songs = new List<Song>();
        }

        public bool AddSong(Song song)
        {
            if (song == null) return false;
            song.playlist = this;
            Songs.Add(song);
            return true;
        }
    }
}