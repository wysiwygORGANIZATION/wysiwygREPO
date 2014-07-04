using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using iRadioDEIplaylist.Controllers;
using iRadioDEIplaylist.Models;

namespace iRadioDEIplaylist
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelpdeskWS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HelpdeskWS.svc or HelpdeskWS.svc.cs at the Solution Explorer and start debugging.
    public class HelpdeskWS : IHelpdeskWS
    {
        public IEnumerable<HelpdeskMusic> MusicsRequest()
        {
            UsersContext db = new UsersContext();
            List<Music> musics = db.Musics.ToList();
            List<HelpdeskMusic> hmusics = new List<HelpdeskMusic>();
            foreach (Music m in musics)
            {
                hmusics.Add(TranslateToHelpdeskMusic(m));
            }
            return hmusics;
        }

        public void AddPlaylist(IEnumerable<HelpdeskMusic> hmusics)
        {
            UsersContext db = new UsersContext();
            List<Music> musics = new List<Music>();
            foreach (HelpdeskMusic hm in hmusics.ToList())
                musics.Add(db.Musics.Find(hm.MusicId));
            Playlist play = new Playlist
            {
                Musics = musics,
                PlaylistActive=true,
                PlaylistVotes=0,
                UserId=1
            };
            db.Playlists.Add(play);
            db.SaveChanges();
        }

        private HelpdeskMusic TranslateToHelpdeskMusic(Music m)
        {
            return new HelpdeskMusic
            {
                MusicId = m.MusicId,
                MusicName = m.MusicName,
                MusicDuration = m.MusicDuration,
                GenreName = m.Genre.GenreName,
                AlbumName = m.Album.AlbumName,
                ArtistName = m.Album.Artist.ArtistName
            };
        }
    }
}
