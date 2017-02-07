using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordStore.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalTracks { get; set; }
        public string ReleaseDate { get; set; }
        public int BandId { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
        public virtual Band Band { get; set; }
    }
}