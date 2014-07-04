using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace iRadioDEIplaylist.Models
{
    public class PlaylistViewModel
    {
        public List<Music> Musics { get; set; }
        public List<CheckBox> CheckBoxes { get; set; } 
    }
}