using MovieShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class GenresController : Controller
    {
        private IGenreService _genreService;
        public GenresController()
        {

            _genreService = new GenreService();
        }
        // GET: Genres
        [HttpGet]
        public PartialViewResult Index()
        
        {
            var genres = _genreService.GetAllGenres().OrderBy(g => g.Name).ToList();
            return PartialView("GenresView", genres);
        }
    }
}