using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using iRadioDEIplaylist.Models;

namespace iRadioDEIplaylist
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PublisherWS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PublisherWS.svc or PublisherWS.svc.cs at the Solution Explorer and start debugging.
    public class PublisherWS : IPublisherWS
    {

        public string NewAlbums(PublisherMusic s)
        {

            UsersContext db = new UsersContext();
            List<Music> musics = new List<Music>();
            //foreach (PublisherMusic m in pmusics)
            // {
            List<Artist> la = db.Artists.Where(art => art.ArtistName == s.ArtistName).ToList();
            Artist a = null;
            if (la.Count > 0)
            {
                a = la.ElementAt(0);
            }
            if (a == null)
            {
                a = new Artist();
                a.ArtistName = s.ArtistName;
                db.Artists.Add(a);
                db.SaveChanges();
                a = (Artist)db.Artists.Where(art => art.ArtistName == s.ArtistName).ToList().ElementAt(0);
            }

            List<Genre> lg = db.Genres.Where(gen => gen.GenreName == s.GenreName).ToList();
            Genre g = null;

            if (lg.Count > 0)
            {
                g = lg.ElementAt(0);
            }

            if (g == null)
            {
                g = new Genre();
                g.GenreName = s.GenreName;
                db.Genres.Add(g);
                db.SaveChanges();
                g = (Genre)db.Genres.Where(gen => gen.GenreName == s.GenreName).ToList().ElementAt(0);
            }

            Music music = new Music { MusicName = s.MusicName, MusicDuration = s.MusicDuration, Album = new Album { AlbumName = s.AlbumName, ArtistId = a.ArtistId }, GenreId = g.GenreId };
            db.Musics.Add(music);
            db.SaveChanges();
            //}*/


            return "1";
        }
    }
}
