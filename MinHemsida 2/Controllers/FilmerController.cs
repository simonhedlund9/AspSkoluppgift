using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinHemsida_2.Controllers
{
    [Authorize] // Authorize har jag på alla controllers i min solution för att göra så att man måste vara inloggad för att visa mina views.
    public class FilmerController : Controller
    {
        private FilmerDBEntities db = new FilmerDBEntities();
        // GET: Filmer
        
        public ActionResult Index()
        {
            //skickar filmer till view
            List<Film> Filmlista = db.Film.ToList();
            return View(Filmlista);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //Controllern som är kopplad till att lägga till en ny film i databasen
        public ActionResult Create(Film NyFilm)
        {
            db.Film.Add(NyFilm);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}