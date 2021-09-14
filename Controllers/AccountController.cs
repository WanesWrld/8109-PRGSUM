using _8109_PRG522SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _8109_PRG522SA.Models;
using System.Data.SqlClient;

namespace _8109_PRG522SA.Controllers
{

    public class AccountController : Controller
    {
        // GET: Account
        WizwheelDataBaseEntities1 db = new WizwheelDataBaseEntities1();

             
       public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
      
       
        [HttpPost]
        public ActionResult Register(Reg reg)
        {
            if (db.Regs.Any(x => x.Email == reg.Email))
            {
                ViewBag.Notification = "This account Exists";
                return View();
            }
            else
            {
                Session["IdTT"] = reg.Id.ToString();
                Session["EmailTT"] = reg.Email.ToString();
                db.Regs.Add(reg);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            

        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Reg reg)
        {

            var checkLogin = db.Regs.Where(x => x.Email.Equals(reg.Email)
                 && x.Password_.Equals(reg.Password_)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["IdTT"] = reg.Id.ToString();
                Session["EmailTT"] = reg.Email.ToString();
                ViewBag.Notification = "You are logged in";
                return RedirectToAction("Portfolio", "Home1");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or password";
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}

