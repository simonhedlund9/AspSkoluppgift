using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinHemsida_2.Controllers
{
    public class FilmerDBController : Controller
    {
        private FilmerDBEntities db = new FilmerDBEntities();

        // GET: FilmerDB
        public ActionResult Index()
        {
            return View(db.Film.ToList());
        }
    }
}