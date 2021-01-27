using AssertusApp.Models;
using AssertusApp.Models.DB;
using AssertusApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AssertusApp.Controllers
{
    public class LoginController : Controller
    {


        //private readonly AssertusDatabaseEntities _context;
        ////AppContext _context;
        //public LoginController(AssertusDatabaseEntities context)
        //{
        //    _context = context;
        //}

        public ActionResult Index()
        {
            return View("~/Views/Login/_Index.cshtml");
        }


        [HttpPost]
        public ActionResult Login(CurrentUser objUser)
        {
            Session["userName"] = objUser.userName;
         
            return RedirectToAction("Get", "MyContacts");
           
        }
        [HttpGet]
        public ActionResult Logoff()
        {
            Session["userName"] = null;
           
            return View("~/Views/Login/_Index.cshtml");

        }


    }
}

//using AssertusApp.Models;
//using AssertusApp.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;


//namespace AssertusApp.Controllers
//{
//    public class MyContactsController : Controller
//    {
//        public ActionResult Index(CurrentUser user)
//        {


//            Console.WriteLine("Hello World");


//            return View("~/Views/MyContacts/_Index.cshtml", new MyContactsViewModel
//            {
//                User = user
//            });
//        }

//    }
//}

