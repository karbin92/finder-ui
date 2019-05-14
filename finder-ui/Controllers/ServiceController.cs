using finder_ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finder_ui.Controllers
{
    public class ServiceController : Controller
    {
        Group3ServiceReference.Service1Client client = new Group3ServiceReference.Service1Client();

        // GET: Service
        public ActionResult Index()
        {
            return View(client.GetAllServiceData());
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(
            int type,
            int creatorId,
            int serviceStatusId,
            string picture,
            string title,
            string description,
            double price,
            DateTime? startDate,
            DateTime? endDate,
            bool timeNeeded,
            int subCategoryId)
        {
            try
            {
                // TODO: Add insert logic here
                CreateServiceObject createServiceObject = new CreateServiceObject(
                    type,
                    creatorId,
                    serviceStatusId,
                    picture,
                    title,
                    description,
                    price,
                    startDate,
                    endDate,
                    timeNeeded,
                    subCategoryId);

                client.CreateService(
                    createServiceObject.Type,
                    createServiceObject.CreatorId,
                       createServiceObject.ServiceStatusId,
                       createServiceObject.Picture,
                       createServiceObject.Title,
                       createServiceObject.Description,
                       createServiceObject.Price,
                       createServiceObject.StartDate,
                       createServiceObject.EndDate,
                       createServiceObject.TimeNeeded,
                       createServiceObject.SubCategoryId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: Service/Edit/5
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

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            return View(client.GetServiceById(id));
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                client.DeleteService(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
