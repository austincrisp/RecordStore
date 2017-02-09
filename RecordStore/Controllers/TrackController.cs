using RecordStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrackTitle,Length,AlbumId")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Tracks", "Band", new { id = track.AlbumId });
            }

            return View(track);
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
            db.SaveChanges();
            return RedirectToAction("Tracks", "Band", new { id = track.AlbumId });
        }
    }
}