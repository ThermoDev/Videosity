using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;

using Videosity.Models;
using Videosity.ViewModels;

namespace Videosity.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        // Constructor
        public MoviesController() {
            _context = new ApplicationDbContext();
        }

        // Dispose of the _context
        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }


        //GET: Movies/
        public ActionResult Index() {
            var movieModel = new IndexMovieViewModel() {
                Movies = _context.Movies.Include(m => m.Genre).ToList()
            };

            return View(movieModel);
        }

        [Route("movies/{id}") ]
        public ActionResult SpecificMovie(int id) {
            return View(_context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id));
        }

        // GET: Movies/Random
        public ActionResult Random() {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer> {
                new Customer {Name = "Customer One" },
                new Customer {Name = "Customer One" }
            };

            var viewModel = new RandomMovieViewModel() {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }


        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month) {
            return Content(year + "/" + month);
        }
    }
}