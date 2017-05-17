using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Niall_Firmstep.Models;

namespace Niall_Firmstep.Controllers
{
    public class QueueItemsController : Controller
    {
        QueueItemContext db = new QueueItemContext();

        // GET: QueueItems
        public ActionResult Index()
        {
            List<QueueItem> qList = db.QueueItems.ToList();
            String now = DateTime.Now.ToShortDateString();
            String timeNow = DateTime.Now.ToLocalTime().ToString();
            ViewBag.MyDate = now;
            ViewBag.MyTime = timeNow;
            return View(qList);
        }
        // GET: QueueItems
        public ActionResult MyIndex()
        {
            List<QueueItem> qList = db.QueueItems.ToList();
            String now = DateTime.Now.ToShortDateString();
            ViewBag.MyTime = now;
            return View(qList);
        }

        public ActionResult SelectCategory()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Citizen", Value = "Citizen" });

            items.Add(new SelectListItem { Text = "Organisation", Value = "Organisation" });

            //"_" is equivalent to anonymous
            items.Add(new SelectListItem { Text = "_", Value = "Anonymous", Selected = true });



            ViewBag.ClientType = items;

            return View();
        }

        public ActionResult CategoryChosen(string clientType)
        {
            //logic to display correct client input view
            
            switch (clientType)
            {
                case "Citizen":
                    return RedirectToAction("CreateCitizen");
                    
                   
                case "Organisation":

                    return RedirectToAction("CreateOrganisation");


                case "Anonymous":

                    return RedirectToAction("CreateAnonymous");

                   
            }



            return RedirectToAction("Index");

        }
    
        //public ActionResult Index()
        //{
        //    //will return current queue items
        //    //anything set to served = false;
        //    return View();
        //}

        // GET: QueueItems/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // get: QueueItems/Select
       public ActionResult Select()
        {
           
                return View();
           
        }
        // POST: QueueItems/Select
        
        [HttpPost]
        public ActionResult Select(String customerType )
        {   try
            {
                // TODO: Add insert logic here 
                if (customerType == "Citizen")
                {
                    //not working
                    return RedirectToAction("QueueItems","CreateCitizen");
                }
                else if (customerType == "Organisation")
                {
                   return RedirectToAction("CreateOrganisation");
                }
            }

            catch
            {
                return View();
            }

            return View();
        }
        // GET: QueueItems/Create
        public ActionResult CreateCitizen()
          {
            return View();
        }

        // POST: QueueItems/Create
        [HttpPost]
        public ActionResult CreateCitizen([Bind(Include = "FirstName, LastName, myTitle, service")] QueueItem qi)
        {
            qi.type = "Citizen";

            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    db.QueueItems.Add(qi);

                    db.SaveChanges();
                    // return RedirectToAction("Index");
                }

                return RedirectToAction("Index");






            }
            catch
            {
                return View();
            }
        }

        // GET: QueueItems/CreateOrganisation

        public ActionResult CreateOrganisation()
        {
            return View();
        }
       

        // POST: QueueItems/CreateOrganisation
        [HttpPost]
        public ActionResult CreateOrganisation([Bind(Include = "FirstName, service")] QueueItem qi)
        {

            qi.type = "Organisation";

            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    db.QueueItems.Add(qi);
                    
                    db.SaveChanges();
                   // return RedirectToAction("Index");
                }

                return RedirectToAction("Index");






            }
            catch
            {
                return View();
            }
        }
        // GET: QueueItems/CreateOrganisation

        public ActionResult CreateAnonymous()
        {
            return View();
        }


        // POST: QueueItems/CreateOrganisation
        [HttpPost]
        public ActionResult CreateAnonymousn([Bind(Include = "service")] QueueItem qi)
        {

            qi.type = "Anonymous";

            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    db.QueueItems.Add(qi);

                    db.SaveChanges();
                    // return RedirectToAction("Index");
                }

                return RedirectToAction("Index");






            }
            catch
            {
                return View();
            }
        }

        // GET: QueueItems/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QueueItems/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QueueItems/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QueueItems/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                QueueItem qi = db.QueueItems.Find(id);
                db.QueueItems.Remove(qi);
                db.SaveChanges();
                return RedirectToAction("Index");
                // TODO: Add delete logic here

                
            }
            catch
            {
                return View();
            }
        }
    }
}
