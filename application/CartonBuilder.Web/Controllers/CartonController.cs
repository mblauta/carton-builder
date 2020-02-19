using CartonBuilder.Data;
using CartonBuilder.Models;
using CartonBuilder.Web.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using DataServices = CartonBuilder.Data.Services;

namespace CartonBuilder.Web.Controllers
{
    public class CartonController : Controller
    {
        private DataServices.CartonService _cartonService = new DataServices.CartonService();
        private DataServices.EquipmentService _equipmentService = new DataServices.EquipmentService();
        private DataServices.CartonDetailService _cartonDetailService = new DataServices.CartonDetailService();

        // GET: Carton
        public ActionResult Index()
        {
            // Retrieve a list of cartons currently in the database...
            var cartonIndexViewModel = new CartonIndexViewModel()
            {
                Cartons = _cartonService.ListCartons()
            };

            return View(cartonIndexViewModel);
        }

        // GET: Carton/Details/5
        public ActionResult Details(int? id)
        {
            // Early exit if the carton ID is not provided. There's really nothing to do.
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Retrieve carton for the given ID...
            Carton carton = _cartonService.GetCarton(id.Value);

            // Return HTTP 404 if we get NULL from the service (i.e., no records found
            // matching the given ID).
            if (carton == null)
            {
                return HttpNotFound();
            }

            var cartonDetailsViewModel = new CartonDetailsViewModel()
            {
                Id = carton.Id,
                CartonNumber = carton.CartonNumber
            };

            return View(cartonDetailsViewModel);
        }

        #region Create

        // GET: Carton/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carton/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, CartonNumber")] CartonCreateViewModel cartonCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                _cartonService.AddCarton(cartonCreateViewModel);
                return RedirectToAction("Index");
            }

            return View(cartonCreateViewModel);
        }

        #endregion Create

        #region Edit

        // GET: Carton/Edit/5
        public ActionResult Edit(int? id)
        {
            // Early exit if the carton ID is not provided. There's really nothing to do.
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Retrieve the carton for the given ID...
            var carton = _cartonService.GetCarton(id.Value);
            if (carton == null)
            {
                return HttpNotFound();
            }

            var cartonEditViewModel = new CartonEditViewModel()
            {
                Id = carton.Id,
                CartonNumber = carton.CartonNumber
            };

            return View(cartonEditViewModel);
        }

        // POST: Carton/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, CartonNumber")] CartonEditViewModel cartonEditViewModel)
        {
            if (ModelState.IsValid)
            {
                _cartonService.UpdateCarton(cartonEditViewModel);
                return RedirectToAction("Index");
            }

            return View(cartonEditViewModel);
        }

        #endregion Edit

        #region Delete

        // GET: Carton/Delete/5
        public ActionResult Delete(int? id)
        {
            // Early exit if the carton ID is not provided. There's really nothing to do.
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Retrieve carton for the given ID...
            var cartonDeleteViewModel = new CartonDeleteViewModel()
            {
                Carton = _cartonService.GetCarton(id.Value)
            };

            // Return HTTP 404 if we get NULL from the service (i.e., no records found
            // matching the given ID).
            if (cartonDeleteViewModel.Carton == null)
            {
                return HttpNotFound();
            }

            return View(cartonDeleteViewModel);
        }

        // POST: Carton/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _cartonService.RemoveCarton(id);
            return RedirectToAction("Index");
        }

        #endregion Delete

        // GET: Carton/5/ListAvailableEquipment
        public ActionResult ListAvailableEquipment(int cartonId)
        {
            // Retrieve the carton with the ID provided. This also ensures that we have a
            // valid carton to add equipment to.
            var carton = _cartonService.GetCarton(cartonId);
            if (carton == null)
            {
                return HttpNotFound();
            }

            var cartonListAvailableEquipmentViewModel = new CartonListAvailableEquipmentViewModel()
            {
                Carton = carton,
                EquipmentList = _equipmentService.ListAvailableEquipmentForCarton(carton.Id)
            };

            return View(cartonListAvailableEquipmentViewModel);
        }

        // GET: Carton/5/AddEquipment/9
        public ActionResult AddEquipment(int cartonId, int equipmentId)
        {
            // Retrieve the carton with the ID provided. This also ensures that we have a
            // valid carton to add equipment to.
            var carton = _cartonService.GetCarton(cartonId);
            if (carton == null)
            {
                return HttpNotFound();
            }

            // Retrieve the equipment with the ID provided. This also ensures that we are
            // adding a valid equipment to the carton.
            var equipment = _equipmentService.GetEquipment(equipmentId);
            if (equipment == null)
            {
                return HttpNotFound();
            }

            // Add equipment to carton...
            _cartonDetailService.AddEquipmentToCarton(cartonId, equipmentId);
            return RedirectToRoute("CartonOperation", new { cartonId = cartonId, action = "ListAvailableEquipment" });
        }

        // GET: Carton/5/ListAddedEquipment
        public ActionResult ListAddedEquipment(int cartonId)
        {
            // Retrieve the carton with the ID provided. This also ensures that we have a
            // valid carton to add equipment to.
            var carton = _cartonService.GetCarton(cartonId);
            if (carton == null)
            {
                return HttpNotFound();
            }

            var cartonListAddedEquipmentViewModel = new CartonListAddedEquipmentViewModel()
            {
                Carton = carton,
                EquipmentList = _equipmentService.ListAddedEquipmentForCarton(carton.Id)
            };
            return View(cartonListAddedEquipmentViewModel);
        }

        public ActionResult RemoveEquipment(int cartonId, int equipmentId)
        {
            // Retrieve the carton with the ID provided. This also ensures that we have a
            // valid carton to add equipment to.
            var carton = _cartonService.GetCarton(cartonId);
            if (carton == null)
            {
                return HttpNotFound();
            }

            // Retrieve the equipment with the ID provided. This also ensures that we are
            // adding a valid equipment to the carton.
            var equipment = _equipmentService.GetEquipment(equipmentId);
            if (equipment == null)
            {
                return HttpNotFound();
            }

            // Add equipment to carton...
            _cartonDetailService.RemoveEquipmentFromCarton(cartonId, equipmentId);
            return RedirectToRoute("CartonOperation", new { cartonId = cartonId, action = "ListAddedEquipment" });
        }
    }
}
