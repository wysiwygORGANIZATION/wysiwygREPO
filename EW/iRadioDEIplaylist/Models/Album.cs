using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace iRadioDEIplaylist.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        [Required]
        public string AlbumName { get; set; }

        [Required]
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}