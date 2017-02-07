using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordStore.Models
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Formed { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}