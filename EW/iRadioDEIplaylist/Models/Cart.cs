using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iRadioDEIplaylist.Models
{
    public class Cart
    {
        public Cart()
        {
            Musics = new List<Music>();
        }

        [Key]
        [ForeignKey("UserProfile")]//this UserProfile refers to this class UserId, which is also a foreign key
        public int UserId { get; set; }
        
        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<Music> Musics { get; set; }
    }
}