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
            List<Group3ServiceReference.ServiceStatusType> statuses = client.GetServiceStatusTypes().ToList();
            List<Group3ServiceReference.SubCategory> subCategories = client.GetSubCategories().ToList();
            List<Group3ServiceReference.ServiceType> serviceTypes = client.GetTypes().ToList();

            CreateServiceObject createServiceObject = new CreateServiceObject(statuses, subCategories, serviceTypes);
            return View(createServiceObject);
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
                List<Group3ServiceReference.ServiceStatusType> statuses = client.GetServiceStatusTypes().ToList();
                List<Group3ServiceReference.SubCategory> subCategories = client.GetSubCategories().ToList();
                List<Group3ServiceReference.ServiceType> serviceTypes = client.GetTypes().ToList();

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
                return RedirectToAction("Error");
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            Group3ServiceReference.Service service = client.GetServiceById(id);
            List<Group3ServiceReference.ServiceStatusType> statuses = client.GetServiceStatusTypes().ToList();
            List<Group3ServiceReference.SubCategory> subCategories = client.GetSubCategories().ToList();
            List<Group3ServiceReference.ServiceType> serviceTypes = client.GetTypes().ToList();
    
            EditServiceObject editService = new EditServiceObject(
                service.Id,
                service.ServiceType.Id,
                service.ServiceStatus.Id,
                service.Picture,
                service.Title,
                service.Description,
                service.Price,
                service.StartDate,
                service.EndDate,
                service.TimeNeeded,
                service.SubCategory.Id,
                statuses,
                subCategories,
                serviceTypes
                );

            return View(editService);
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(
            int id, 
            int type,
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
                var x = subCategoryId;
                bool editOk = 
                client.EditService(
                    id,
                    type,
                    serviceStatusId,
                    picture,
                    title,
                    description,
                    price,
                    startDate,
                    endDate,
                    timeNeeded,
                    subCategoryId); 

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
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
                client.DeleteService(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
        
        public ActionResult Error()
        {
            return View();
        }
    }
}
