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
    public class ManageGenresController : Controller
    {
        private UsersContext db = new UsersContext();

        public bool Exists(Genre genre)
        {
            if (db.Genres.ToList().Find(a => a.GenreName == genre.GenreName) != null)
                return true;
            return false;
        }

        //
        // GET: /ManageGenres/

        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        //
        // GET: /ManageGenres/Details/5

        public ActionResult Details(int id = 0)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // GET: /ManageGenres/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManageGenres/Create

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (Exists(genre))
                ModelState.AddModelError("", "There is already a Genre named " + genre.GenreName);

            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        //
        // GET: /ManageGenres/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // POST: /ManageGenres/Edit/5

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (Exists(genre))
                ModelState.AddModelError("", "There is already a Genre named " + genre.GenreName);

            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        //
        // GET: /ManageGenres/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // POST: /ManageGenres/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
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