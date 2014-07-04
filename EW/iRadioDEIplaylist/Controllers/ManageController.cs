using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iRadioDEIplaylist.Controllers
{
    [Authorize(Roles="Manager")]
    public class ManageController : Controller
    {
        //
        // GET: /Manage/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Musics()
        {
            return RedirectToAction("Index", "ManageMusics");
        }

        public ActionResult Genres()
        {
            return RedirectToAction("Index", "ManageGenres");
        }

        public ActionResult Artists()
        {
            return RedirectToAction("Index", "ManageArtists");
        }

        public ActionResult Albums()
        {
            return RedirectToAction("Index", "ManageAlbums");
        }

        public ActionResult Playlists()
        {
            return RedirectToAction("Index", "ManagePlaylists");
        }

        public ActionResult NewSounds()
        {
            return RedirectToAction("Index", "ManageNewSounds");
        }
    }
}
