using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Videosity.Models;
using Videosity.ViewModels;

namespace Videosity.Controllers
{
    public class MoviesController : Controller
    {
        //GET: Movies/
        public ActionResult Index() {
            var movies = new List<Movie>() {
                new Movie () {Name="Shrek"},
                new Movie () {Name="The Matrix"},
                new Movie () {Name="Lord of the Rings: Fellowship of the Ring"}
            };

            var movieModel = new IndexMovieViewModel() {
                Movies = movies
            };

            return View(movieModel);
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