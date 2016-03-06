using System;
using JamSesh69.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JamSesh69.Models
{
    [Table("Songs")]
    public class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Enums.SongType Type { get; set; }
        public string StreamUrl { get; set; }
        public Playlist playlist { get; set; }

        public Song(string title, Enums.SongType type, string streamUrl)
        {
            this.Title = title;
            this.Type = type;
            this.StreamUrl = streamUrl;
        }
    }
}