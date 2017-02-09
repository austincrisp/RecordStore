using System;
using System.Collections.Generic;
using RecordStore.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Genre,Formed")] Band band)
        {
            if (ModelState.IsValid)
            {
                db.Entry(band).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(band);
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Band band = db.Bands.Find(id);
            db.Bands.Remove(band);
            db.SaveChanges();
            return RedirectToAction("Index");
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