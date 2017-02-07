using System;
using System.Collections.Generic;
using RecordStore.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}