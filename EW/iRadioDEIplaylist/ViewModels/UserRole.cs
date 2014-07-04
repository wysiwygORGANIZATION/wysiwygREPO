using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using iRadioDEIplaylist.Models;

namespace iRadioDEIplaylist.ViewModels
{
    public class UserRole
    {
        [Required]
        [Display(Name = "Role")]
        public string [] Role { get; set; }

        public virtual UserProfile User { get; set; }
    }
}