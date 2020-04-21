using MovieShop.Entities;
using MovieShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class CastController : Controller
    {
        // GET: Cast
        private ICastService _castService;
        public CastController()
        {
            _castService = new CastService();
        }
        public ActionResult Index()
        {
            var casts = _castService.GetAllCasts();
            return View(casts);
        }

        //step 1 create a action method that returns empty view to enter Cast info
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cast cast)
        {
            // save this information to cast Table
            _castService.Add(cast);
            return RedirectToAction("Index");
            //return View();
        }
    }
}