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

        public ActionResult New() {
            var genres = _context.Genres.ToList();
            var newMovieViewModel = new MovieFormViewModel {
                Genres = genres
            };

            ViewBag.Message = "New Movie";

            return View("MovieForm", newMovieViewModel);
        }

        public ActionResult Edit(int id) {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null) {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            ViewBag.Message = "Edit Movie";
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie) {

            if (!ModelState.IsValid) {

                var viewModel = new MovieFormViewModel {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0) {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else {
                var movieToUpdate = _context.Movies.Single(c => c.Id == movie.Id);

                movieToUpdate.Id = movie.Id;
                movieToUpdate.Name = movie.Name;
                movieToUpdate.ReleaseDate = movie.ReleaseDate;
                movieToUpdate.GenreId = movie.GenreId;
                movieToUpdate.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        //GET: Movies/
        public ActionResult Index() {
            var movieModel = new IndexMovieViewModel() {
                Movies = _context.Movies.Include(m => m.Genre).ToList()
            };

            return View(movieModel);
        }

        [Route("movies/Specific/{id}") ]
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