using JamSesh69.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JamSesh.Models
{
    public class Jammer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public List<Playlist> Playlists { get; set; }
        //public List<Session> Sessions {get;set;}

        public Jammer()
        {
            Playlists = new List<Playlist>();
        }

        public bool CreatePlaylist(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            var playlist = new Playlist(name, this);
            Playlists.Add(playlist);
            return true;
        }

    }
}