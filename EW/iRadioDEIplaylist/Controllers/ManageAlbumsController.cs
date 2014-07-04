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
    public class ManageAlbumsController : Controller
    {
        private UsersContext db = new UsersContext();

        public bool Exists(Album album)
        {
            if (db.Albums.Where(a => a.ArtistId == album.ArtistId).ToList().Find(a => a.AlbumName == album.AlbumName) != null)
                return true;
            return false;
        }

        //
        // GET: /ManageAlbums/

        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artist);
            return View(albums.ToList());
        }

        //
        // GET: /ManageAlbums/Details/5

        public ActionResult Details(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // GET: /ManageAlbums/Create

        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName");
            return View();
        }

        //
        // POST: /ManageAlbums/Create

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (Exists(album))
                ModelState.AddModelError("", "There is already an Album of that Artist named " + album.AlbumName);

            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName", album.ArtistId);
            return View(album);
        }

        //
        // GET: /ManageAlbums/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName", album.ArtistId);
            return View(album);
        }

        //
        // POST: /ManageAlbums/Edit/5

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (Exists(album))
                ModelState.AddModelError("", "There is already an Album of that Artist named " + album.AlbumName);

            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName", album.ArtistId);
            return View(album);
        }

        //
        // GET: /ManageAlbums/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // POST: /ManageAlbums/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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