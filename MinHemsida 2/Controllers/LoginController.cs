using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinHemsida_2.Controllers
{
    public class LoginController : Controller
    {
        LoginDBEntities db = new LoginDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Models.Inloggning Inlogg)
        {
            bool ValidUser = false;
            
            ValidUser = KollaAnvändare(Inlogg.Användarnamn, Inlogg.Lösenord); // sätter in användarnamn och lösenord in i variabeln validuser
            if (ValidUser == true)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Inlogg.Användarnamn, false); //vid lyckad inloggning skickas användaren till startsidan.

            }
            return View();
        }

        private bool KollaAnvändare (string Användarnamn, string Lösenord) //tar emot två strings
        { // denna funktion kollar ifall inloggnings uppgifterna som ligger i databasen är samma som de som användaren har matat in
            var användare = from rader in db.Login 
                            where rader.Användarnamn.ToUpper() == Användarnamn.ToUpper() // .ToUpper gör så att användarnamnet inte är case sensitive
                            && rader.Lösenord == Lösenord
                            select rader;

            
            if (användare.Count() == 1)
            {
                //returnerar true ifall inmatningen matchade
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}