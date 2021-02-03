using AssertusApp.Models;
using AssertusApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssertusApp.Models.DB;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace AssertusApp.Controllers
{
    public class MyContactsController : Controller
    {
      
        public ActionResult Get()
        {
            if(Session["userName"] == null)
            {


                return View("~/Views/Login/_Index.cshtml");

            }
            else
            {
                AssertusDatabaseEntities _context = new AssertusDatabaseEntities();

                var model = _context.Contacts.ToList();
                return View("~/Views/MyContacts/View.cshtml", model);


            }
        


        }
        [HttpGet]
        public ActionResult Get(string searchString)
        {
            if (Session["userName"] == null)
            {

                return View("~/Views/Login/_Index.cshtml");

            }
            else
            {
                AssertusDatabaseEntities _context = new AssertusDatabaseEntities();
                if (searchString == null || searchString == "")
                {
                    var model = _context.Contacts.ToList();
                    return View("~/Views/MyContacts/View.cshtml", model);
                }
                else
                {
                    if(searchString.Length > 10)
                    {
                        searchString = searchString.Substring(0,10);
                       
                    }
                    
                    var Searchmodel = _context.Contacts.Where(x => x.Name.Contains(searchString)).ToList();
                    return View("~/Views/MyContacts/View.cshtml", Searchmodel);

                }
            }

        }
        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
        public string CreateUser(Contact contact)
        {
            if (Session["userName"] == null)
            {

                Get();
                return null;
            }
            else
            {
                AssertusDatabaseEntities _context = new AssertusDatabaseEntities();

                try
                {

                    if (ModelState.IsValid)
                    {
                        contact.LastUpdateUserName = Session["userName"].ToString();
                        contact.LastUpdate = DateTime.Now;
                        _context.Contacts.Add(contact);
                        _context.SaveChanges();
                        Get();
                        return null;
                    }
                    else
                    {
                    }
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }

                return RenderPartialViewToString("/Views/MyContacts/Modal/CreateModal.cshtml", contact);
            }
        }
        public ActionResult CreateModal()
        {
            if (Session["userName"] == null)
            {

                return View("~/Views/Login/_Index.cshtml");

            }
            else
            {
             
                return PartialView("/Views/MyContacts/Modal/CreateModal.cshtml", new Contact());
                //return View("~/Views/MyContacts/Details.cshtml", model);
            }
        }



         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (Session["userName"] == null)
            {

                return View("~/Views/Login/_Index.cshtml");

            }
            else
            {
                AssertusDatabaseEntities _context = new AssertusDatabaseEntities();

                try
                {
                    if (ModelState.IsValid)
                    {
                        contact.LastUpdateUserName = Session["userName"].ToString();
                        contact.LastUpdate = DateTime.Now;
                        _context.Contacts.Add(contact);
                        _context.SaveChanges();
                        return Content("1");
                    }
                    else {

                        return PartialView("~/Views/MyContacts/Modal/CreateModal.cshtml", contact);
                    }
                
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }

                return View(contact);
            }
        }
        public ActionResult Edit(int id)
        {
            if (Session["userName"] == null)
            {

                return View("~/Views/Login/_Index.cshtml");

            }
            else
            {
                AssertusDatabaseEntities _context = new AssertusDatabaseEntities();
                var model = _context.Contacts.FirstOrDefault(x => x.ContactID == id);
                return View("~/Views/MyContacts/Edit.cshtml", model);
            }
        }

        public ActionResult Details(int id)
        {
            if (Session["userName"] == null)
            {

                return View("~/Views/Login/_Index.cshtml");

            }
            else
            {
                AssertusDatabaseEntities _context = new AssertusDatabaseEntities();
                var model = _context.Contacts.FirstOrDefault(x => x.ContactID == id);
              return PartialView("/Views/MyContacts/Modal/ViewModal.cshtml", model);
                //return View("~/Views/MyContacts/Details.cshtml", model);
            }
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (Session["userName"] == null)
            {

                return View("~/Views/Login/_Index.cshtml");

            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }
                AssertusDatabaseEntities _context = new AssertusDatabaseEntities();
                var contactToUpdate = _context.Contacts.Find(id);


                if (TryUpdateModel(contactToUpdate, ""))
                {
                    try
                    {
                        contactToUpdate.LastUpdateUserName = Session["userName"].ToString();
                        contactToUpdate.LastUpdate = DateTime.Now;
                        _context.SaveChanges();

                        return RedirectToAction("Get");
                    }
                    catch (RetryLimitExceededException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }

                return View(contactToUpdate);
            }
        }

    }
}

