using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iRadioDEIplaylist.MusicPreferencesWS;
using iRadioDEIplaylist.Models;
using System.Web.Services.Protocols;

//cliente que envia informação sobre a playlist (quando é criada) e ouvinte ao WebService do MusicPreferences

namespace iRadioDEIplaylist
{
    public class Client
    {
        public void InformWS(Playlist play)
        {

            Service serv = new Service();

            string playID = play.PlaylistId.ToString();
            string adress = play.UserProfile.UserAddress;
            string age = (DateTime.Now.Year - play.UserProfile.UserBirthDate.Year).ToString();
            List<Preference> Lp = new List<Preference>();

            foreach (Music m in play.Musics)
            {
                Preference pref = new Preference();
                pref.PlaylistId = playID;
                pref.MusicName = m.MusicName;
                pref.GenreName = m.Genre.GenreName;
                pref.AlbumName = m.Album.AlbumName;
                pref.ArtistName = m.Album.Artist.ArtistName;
                pref.UserAge = age;
                pref.UserAddress = adress;
                Lp.Add(pref);
            }
            try
            {
                serv.SetPreferences(Lp.ToArray());
            }
            catch (SoapHeaderException e)
            { }
        }
    }
}