using iRadioDEIplaylist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace iRadioDEIplaylist
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPublisherWS" in both code and config file together.
    [ServiceContract]
    public interface IPublisherWS
    {
        [OperationContract]
        string NewAlbums(PublisherMusic s);
    }

    [DataContract]
    public class PublisherMusic
    {
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
