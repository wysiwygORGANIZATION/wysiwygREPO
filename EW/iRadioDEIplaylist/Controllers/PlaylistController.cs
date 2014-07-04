using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using iRadioDEIplaylist.Models;
using WebMatrix.WebData;

namespace iRadioDEIplaylist.Controllers
{
    [Authorize]
    public class PlaylistController : Controller
    {
        private UsersContext db = new UsersContext();
        List<Music> musics;

        //
        // GET: /Playlist/

        public ActionResult Index()
        {
            ViewBag.Message = "Registered users can make their own playlist!";
            musics = db.Musics.Include(m => m.Genre).Include(m => m.Album).ToList();
            return View(musics);
        }

        public ActionResult Add(int id)
        {
            int userId = WebSecurity.CurrentUserId;
            Cart c = null;
            c = db.Carts.Find(userId);
            if (c == null)
            {
                c = new Cart();
                c.UserId = userId;
                c.Musics.Add(db.Musics.Find(id));
                db.Carts.Add(c);
            }
            else
            {
                c.Musics.Add(db.Musics.Find(id));
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Playlist");
        }

        public IEnumerable<Music> HelpdeskMusicsRequest()
        {
            return db.Musics.ToList();
        }

        public void HelpdeskAddPlaylist(Playlist play)
        {
            db.Playlists.Add(play);
            db.SaveChanges();
        }

        public Music HelpdeskMusic()
        {
            return db.Musics.Find(1);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
