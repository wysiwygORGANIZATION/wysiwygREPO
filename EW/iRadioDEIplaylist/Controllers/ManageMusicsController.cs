using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iRadioDEIplaylist.Models;

namespace iRadioDEIplaylist.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManageMusicsController : Controller
    {
        private UsersContext db = new UsersContext();

        public bool Exists(Music music)
        {
            if (db.Musics.Where(a => a.AlbumId == music.AlbumId).ToList().Find(m => m.MusicName == music.MusicName) != null)
                return true;
            return false;
        }

        //
        // GET: /ManageMusics/

        public ActionResult Index()
        {
            var musics = db.Musics.Include(m => m.Genre).Include(m => m.Album);
            return View(musics.ToList());
        }

        //
        // GET: /ManageMusics/Details/5

        public ActionResult Details(int id = 0)
        {
            Music music = db.Musics.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }

        //
        // GET: /ManageMusics/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumName");
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName");
            return View();
        }

        //
        // POST: /ManageMusics/Create

        [HttpPost]
        public ActionResult Create(Music music)
        {
            if (Exists(music))
                ModelState.AddModelError("", "There is already a Music of that Album named " + music.MusicName);

            if (ModelState.IsValid)
            {
                db.Musics.Add(music);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", music.GenreId);
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumName", music.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Albums, "ArtistId", "ArtistName", db.Albums.ToList().Find(a => a.AlbumId == music.AlbumId).ArtistId);
            return View(music);
        }

        //
        // GET: /ManageMusics/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Music music = db.Musics.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", music.GenreId);
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumName", music.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName", music.Album.ArtistId);
            return View(music);
        }

        //
        // POST: /ManageMusics/Edit/5

        [HttpPost]
        public ActionResult Edit(Music music)
        {
            if (ModelState.IsValid)
            {
                db.Entry(music).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", music.GenreId);
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumName", music.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName", music.Album.ArtistId);
            return View(music);
        }

        //
        // GET: /ManageMusics/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Music music = db.Musics.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }

        //
        // POST: /ManageMusics/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Music music = db.Musics.Find(id);
            db.Musics.Remove(music);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}