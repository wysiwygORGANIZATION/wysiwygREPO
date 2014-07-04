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
    public class ManageNewSoundsController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /ManageNewSounds/

        public ActionResult Index()
        {
            var newsounds = db.NewSounds.Include(n => n.Playlist);
            return View(newsounds.ToList());
        }

        //
        // GET: /ManageNewSounds/Details/5

        public ActionResult Details(int id = 0)
        {
            NewSound newsound = db.NewSounds.Find(id);
            if (newsound == null)
            {
                return HttpNotFound();
            }
            return View(newsound);
        }

        //
        // GET: /ManageNewSounds/Create

        public ActionResult Create()
        {
            ViewBag.PlaylistId = new SelectList(db.Playlists, "PlaylistId", "PlaylistId");
            return View();
        }

        //
        // POST: /ManageNewSounds/Create

        [HttpPost]
        public ActionResult Create(NewSound newsound)
        {
            if (ModelState.IsValid)
            {
                db.NewSounds.Add(newsound);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaylistId = new SelectList(db.Playlists, "PlaylistId", "PlaylistId", newsound.PlaylistId);
            return View(newsound);
        }

        //
        // GET: /ManageNewSounds/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NewSound newsound = db.NewSounds.Find(id);
            if (newsound == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaylistId = new SelectList(db.Playlists, "PlaylistId", "PlaylistId", newsound.PlaylistId);
            return View(newsound);
        }

        //
        // POST: /ManageNewSounds/Edit/5

        [HttpPost]
        public ActionResult Edit(NewSound newsound)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsound).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaylistId = new SelectList(db.Playlists, "PlaylistId", "PlaylistId", newsound.PlaylistId);
            return View(newsound);
        }

        //
        // GET: /ManageNewSounds/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NewSound newsound = db.NewSounds.Find(id);
            if (newsound == null)
            {
                return HttpNotFound();
            }
            return View(newsound);
        }

        //
        // POST: /ManageNewSounds/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NewSound newsound = db.NewSounds.Find(id);
            db.NewSounds.Remove(newsound);
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