using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace iRadioDEIplaylist.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [Required]
        public string ArtistName { get; set; }
    }
}