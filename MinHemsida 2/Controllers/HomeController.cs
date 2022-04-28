using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinHemsida_2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}