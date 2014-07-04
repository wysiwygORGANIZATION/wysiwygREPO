using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace iRadioDEIplaylist.Models
{
    public class NewSound
    {
        public int NewSoundId { get; set; }

        [DataType(DataType.Date)]
        public DateTime NewSoundDate { get; set; }

        [Required]
        public int PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }
    }
}