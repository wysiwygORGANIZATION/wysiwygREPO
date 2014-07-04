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
    public class ManagePlaylistsController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /ManagePlaylists/

        public ActionResult Index()
        {
            var playlists = db.Playlists.Include(p => p.UserProfile);
            return View(playlists.ToList());
        }

        //
        // GET: /ManagePlaylists/Details/5

        public ActionResult Details(int id = 0)
        {
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        //
        // GET: /ManagePlaylists/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /ManagePlaylists/Create

        [HttpPost]
        public ActionResult Create(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Playlists.Add(playlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", playlist.UserId);
            return View(playlist);
        }

        //
        // GET: /ManagePlaylists/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", playlist.UserId);
            return View(playlist);
        }

        //
        // POST: /ManagePlaylists/Edit/5

        [HttpPost]
        public ActionResult Edit(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", playlist.UserId);
            return View(playlist);
        }

        //
        // GET: /ManagePlaylists/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        //
        // POST: /ManagePlaylists/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Playlist playlist = db.Playlists.Find(id);
            db.Playlists.Remove(playlist);
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