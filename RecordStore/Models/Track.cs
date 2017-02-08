using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordStore.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string TrackTitle { get; set; }
        public string Length { get; set; }
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}