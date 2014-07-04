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
    public class ManageArtistsController : Controller
    {
        private UsersContext db = new UsersContext();

        public bool Exists(Artist artist)
        {
            if (db.Artists.ToList().Find(a => a.ArtistName == artist.ArtistName) != null)
                return true;
            return false;
        }

        //
        // GET: /ManageArtists/

        public ActionResult Index()
        {
            return View(db.Artists.ToList());
        }

        //
        // GET: /ManageArtists/Details/5

        public ActionResult Details(int id = 0)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // GET: /ManageArtists/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManageArtists/Create

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (Exists(artist))
                ModelState.AddModelError("", "There is already an Artist named "+artist.ArtistName);

            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        //
        // GET: /ManageArtists/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /ManageArtists/Edit/5

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            if (Exists(artist))
                ModelState.AddModelError("", "There is already an Artist named " + artist.ArtistName);

            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //
        // GET: /ManageArtists/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /ManageArtists/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
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