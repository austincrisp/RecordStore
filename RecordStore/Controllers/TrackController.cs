using RecordStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecordStore.Controllers
{
    public class TrackController : Controller
    {
        BandAlbumContext db = new BandAlbumContext();

        // GET: Track
        public ActionResult Index()
        {
            ViewBag.AlbumTracks = db.Tracks.OrderBy(t => t.TrackTitle).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Track track)
        {
            db.Tracks.Add(track);
            db.SaveChanges();
            return RedirectToAction("Tracks", "Band", new { id = track.AlbumId });
        }
    }
}