using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace iRadioDEIplaylist.Models
{
    public class Music
    {
        public Music()
        {
            Playlists = new List<Playlist>();
            Carts = new List<Cart>();
        }

        public int MusicId { get; set; }

        [Required]
        public string MusicName { get; set; }

        [Required]
        [Display(Name = "MusicDuration(seconds)")]
        public int MusicDuration { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int AlbumId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}