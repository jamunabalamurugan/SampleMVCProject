using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RainbowEntertainment.Models;
using RainbowEntertainment.DatabaseContext;

namespace RainbowEntertainment.Controllers
{
    public class MovieController : Controller
    {
        private MovieDbContext db = new MovieDbContext();
        public ActionResult Search()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Search(string q)
        {
            var movies = db.Movies.Include(m => m.genre).OrderBy(m => m.MovieName).Where(m => m.MovieName.Contains(q));
            return PartialView("_searchresults", movies);
        }

        public string getRow(string displayName, string fieldValue)
        {
            string strResponse = "";
            strResponse += "<tr style='font size:16pt;'>";
            strResponse += "<td>";
            strResponse += "<b>";
            strResponse += displayName;
            strResponse += "</b>";
            strResponse += "</td>";
            strResponse += "<td>";
            strResponse += fieldValue;
            strResponse += "</td>";
            strResponse += "</tr>";
            return strResponse;
        }
        public ActionResult MovieRatings()
        {
            System.Xml.Linq.XDocument xmlDoc = System.Xml.Linq.XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/MovieRatings/MovieRating.xml"));

            var movies = from m in xmlDoc.Descendants("Movie")
                         select m;
            string strResponse = "<table style='width:100%; padding:30px;'>";
            foreach (var mov in movies)
            {
                strResponse += getRow("Movie Name", mov.Element("Name").Value);
                strResponse += getRow("Director", mov.Element("Director").Value);
                strResponse += getRow("Producer", mov.Element("Producer").Value);
                strResponse += getRow("Cast", mov.Element("Cast").Value);
                string rating = "";
                for (int i = 0; i < Convert.ToInt32(mov.Element("Rating").Value); i++)
                {
                    //rating += "<img src=\"" + System.Web.HttpContext.Current.Server.MapPath("~/Images/Star.png") + "\" style='height:20px; width:20px;'/>";
                    rating += "<img src='../../Images/Star.png' style='height:20px; width:20px;'/>";
                }
                strResponse += getRow("Rating", rating);
                //to insert blank row after each movie rating record
                strResponse += getRow("<br/>", "<br/>");
            }
            strResponse += "</table>";
            ViewBag.movieRatings = strResponse;
            return View();
        }


        [HttpPost]
        /* To accept even null values the nullable type (int?) is used.
           Nullable types can represent all the values 
           of an underlying type, and an additional null value. */

        public ActionResult Index(int? GenreID)
        {
            var movies = db.Movies.Include(m => m.genre);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "strGenre");
            if (GenreID == null)
            {
                //retrieve all records
                movies = movies.OrderBy(k => k.MovieName);
            }
            else
            {
                movies = movies.Where(g => g.GenreID == GenreID).OrderBy(k => k.MovieName);
            }

            return View(movies);
        }


        //
        // GET: /Movie/

        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.genre).OrderBy(k => k.MovieName);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "strGenre");
            return View(movies); 

        }

        //
        // GET: /Movie/Details/5

        public ActionResult Details(long id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // GET: /Movie/Create

        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "strGenre");
            return View();
        }

        //
        // POST: /Movie/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "strGenre", movie.GenreID);
            return View(movie);
        }

        //
        // GET: /Movie/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "strGenre", movie.GenreID);
            return View(movie);
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "strGenre", movie.GenreID);
            return View(movie);
        }

        //
        // GET: /Movie/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Movie/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}