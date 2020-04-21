using MovieShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    [RoutePrefix("movies")]

    
    public class MoviesController : Controller
    {
        // GET: Movies

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var movies = _movieService.GetTopGrossingMovies();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _movieService.GetMovieDetails(id);
            return View(movie);
        }

        //take genre id from url and then call movie service to get a list of movies belonging to that genre
        [HttpGet]
        [Route("genres/{genreId}")]
        public ActionResult Genre(int genreId)
        {
            var movies = _movieService.GetMoviesByGenre(genreId).OrderBy(m => m.Title).ToList();
            return View("MoviesByGenre", movies);
        }

    }
}