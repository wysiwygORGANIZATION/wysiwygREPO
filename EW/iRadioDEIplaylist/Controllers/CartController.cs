using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using iRadioDEIplaylist.Models;
using WebMatrix.WebData;

namespace iRadioDEIplaylist.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Cart/

        public ActionResult Index()
        {
            ViewBag.Message = "Cart content:";
            int userId = WebSecurity.CurrentUserId;
            Cart c = db.Carts.Find(userId);
            if (c == null)
                return View(new Cart());
            return View(c);
        }

        [HttpPost]
        public ActionResult Index(Cart c)//falta acrescentar a verificação do tamanho da playlist
        {
            int userId = WebSecurity.CurrentUserId;
            Cart cart = db.Carts.Find(userId);
            if(cart == null)
                return RedirectToAction("Index");
            //verificação do tamanho da lista comentada para testes mais rápidos--------------
            //int duration = 0;
            //foreach (Music music in cart.Musics.ToList())  
            //    duration += music.MusicDuration;
            //if(duration < 3600 || duration > 3780)    
            //    return RedirectToAction("Index");
            Playlist play = new Playlist(cart.Musics.ToList());
            play.PlaylistActive = true;
            play.PlaylistVotes = 0;
            play.UserId = userId;
            db.Carts.Remove(cart);
            db.Playlists.Add(play);
            db.SaveChanges();

            UserProfile userprofile = db.UserProfiles.Find(userId);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(Credentials.iradioEmail);
            mail.To.Add(userprofile.UserEmail);
            mail.Subject = "New Playlist!";
            string body = "Your new playlist:\n";
            foreach (Music music in play.Musics.ToList())
                body += music.MusicName + "\n";
            mail.Body = body;

            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Credentials = new System.Net.NetworkCredential(Credentials.iradioUser, Credentials.iradioEmailPW);
            SmtpServer.Port = Credentials.port;
            try
            {
                SmtpServer.Send(mail);
            }
            catch (SmtpException e)
            { 

            }

            Client cl = new Client();
            cl.InformWS(play);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}