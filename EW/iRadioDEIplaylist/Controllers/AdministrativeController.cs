using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using iRadioDEIplaylist.Models;
using iRadioDEIplaylist.ViewModels;
using WebMatrix.WebData;

namespace iRadioDEIplaylist.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrativeController : Controller
    {
        private UsersContext db = new UsersContext();

        private string RandomString(int size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public ActionResult Role(int id)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            UserRole userRole = new UserRole();
            userRole.User = userprofile;
            string[] roles = Roles.GetAllRoles();
            int tam = roles.Length;
            string[] rolesWithUser = new string[tam+1];
            for(int i=0;i<roles.Length;i++)
                rolesWithUser[i]=roles[i];
            rolesWithUser[tam] = "User";
            ViewBag.roles = rolesWithUser;
            return View(userRole);
        }

        [HttpPost]
        public ActionResult Role(UserRole userole)
        {
            string role = Request.Form["Role"];
            string user = userole.User.UserName;
            if (!WebSecurity.UserExists(user))
                return HttpNotFound("Username "+user+" was not found!");

            switch(role)
            {
                case "User":
                    Roles.RemoveUserFromRoles(user, Roles.GetAllRoles());
                    break;
                case "Manager":
                    Roles.RemoveUserFromRoles(user, Roles.GetAllRoles());
                    Roles.AddUserToRoles(user, new[] { "Manager" });
                    break;
                case "Administrator":
                    if (!Roles.GetRolesForUser(user).Contains("Manager"))
                        Roles.AddUserToRoles(user, new[] { "Manager" });
                    if (!Roles.GetRolesForUser(user).Contains("Administrator"))
                        Roles.AddUserToRoles(user, new[] { "Administrator" });
                    break;
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Administrative/

        public ActionResult Index(Int32? id)
        {
            if (id != null)
            {
                UserProfile user = db.UserProfiles.Find(id);
                if (!Roles.GetRolesForUser(user.UserName).Contains("Manager"))
                    Roles.AddUsersToRoles(new[] { user.UserName }, new[] { "Manager" });
            }
            ViewBag.Title = "Users";
            return View(db.UserProfiles.ToList());
        }

        //
        // GET: /Administrative/Details/5

        public ActionResult Details(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /Administrative/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrative/Create

        [HttpPost]
        public ActionResult Create(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                if (!WebSecurity.UserExists(userprofile.UserName)) 
                {
                    string passwd = RandomString(6);
                    WebSecurity.CreateUserAndAccount(
                        userprofile.UserName,
                        passwd,
                        new { UserEmail = userprofile.UserEmail, UserBirthDate = userprofile.UserBirthDate, UserAddress = userprofile.UserAddress });
                    
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(Credentials.iradioEmail);
                    mail.To.Add(userprofile.UserEmail);
                    mail.Subject = "Welcome to iRadioMei!";
                    mail.Body = "Username: "+userprofile.UserName+"\nPassword: "+passwd+".\nYou can change the password after the first login.";

                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    SmtpServer.Credentials = new System.Net.NetworkCredential(Credentials.iradioUser, Credentials.iradioEmailPW);
                    SmtpServer.Port = Credentials.port;
                    SmtpServer.Send(mail);
                }
                return RedirectToAction("Index");
            }
            return View(userprofile);
        }

        //
        // GET: /Administrative/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /Administrative/Edit/5

        [HttpPost]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userprofile);
        }

        //
        // GET: /Administrative/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /Administrative/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(userprofile.UserName);
            Membership.DeleteUser(userprofile.UserName, true);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}