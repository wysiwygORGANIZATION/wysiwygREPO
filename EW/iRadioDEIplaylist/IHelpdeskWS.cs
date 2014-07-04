using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace iRadioDEIplaylist
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHelpdeskWS" in both code and config file together.
    [ServiceContract]
    public interface IHelpdeskWS
    {
        [OperationContract]
        IEnumerable<HelpdeskMusic> MusicsRequest();

        [OperationContract]
        void AddPlaylist(IEnumerable<HelpdeskMusic> hmusics);
    }

    [DataContract]
    public class HelpdeskMusic
    {
        [DataMember]
        public int MusicId { get; set; }

        [DataMember]
        public string MusicName { get; set; }

        [DataMember]
        public int MusicDuration { get; set; }

        [DataMember]
        public string GenreName { get; set; }

        [DataMember]
        public string AlbumName { get; set; }

        [DataMember]
        public string ArtistName { get; set; }
    }
}
