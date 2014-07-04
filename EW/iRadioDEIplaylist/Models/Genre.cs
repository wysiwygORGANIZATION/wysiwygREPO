using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace iRadioDEIplaylist.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required]
        public string GenreName { get; set; }
    }
}