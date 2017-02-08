using System;
using System.Collections.Generic;
using RecordStore.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RecordStore.Controllers
{
    public class BandController : Controller
    {
        BandAlbumContext db = new BandAlbumContext();

        // GET: Band
        public ActionResult Index()
        {
            ViewBag.AllBands = db.Bands.OrderBy(b => b.Name).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Band band)
        {
            db.Bands.Add(band);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Band band = db.Bands.Find(id);

            if (ModelState.IsValid)
            {
                db.Entry(band).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Band");
            }

            return View(band);
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Albums(int id)
        {
            Band band = db.Bands.First(b => b.Id == id);
            ViewBag.BandAlbums = db.Albums.OrderBy(a => a.Title).Where(a => a.BandId == id);
            return View(band);
        }

        public ActionResult Tracks(int id)
        {
            Album album = db.Albums.First(a => a.Id == id);
            ViewBag.AlbumTracks = db.Tracks.OrderBy(t => t.TrackTitle).Where(t => t.AlbumId == id);
            return View(album);
        }
    }
}