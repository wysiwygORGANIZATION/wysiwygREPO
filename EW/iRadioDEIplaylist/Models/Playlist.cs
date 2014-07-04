using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace iRadioDEIplaylist.Models
{
    public class Playlist
    {
        public Playlist()
        {
            Musics = new List<Music>();
        }

        public Playlist(List<Music> musics)
        {
            Musics = musics;
        }

        public int PlaylistId { get; set; }

        public int PlaylistVotes { get; set; }

        [Required]
        public bool PlaylistActive { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Music> Musics { get; set; }
    }
}