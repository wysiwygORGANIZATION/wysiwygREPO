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
    public class VotingController : Controller
    {

        private UsersContext db = new UsersContext();
        List<Playlist> playlists;

        //
        // GET: /Voting/

        public ActionResult Index()
        {
            ViewBag.Message = "This page allows unregistered users to vote on playlists they like the most.";
            playlists = db.Playlists.ToList();
            return View(playlists);
        }


        public ActionResult Vote(int id)
        {
            Playlist play = db.Playlists.Find(id);
            play.PlaylistVotes++;
            db.Entry(play).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
