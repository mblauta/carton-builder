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

        private CartonContext db = new CartonContext();

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
            var cartonDetailsViewModel = new CartonDetailsViewModel()
            {
                Carton = _cartonService.GetCarton(id.Value)
            };

            // Return HTTP 404 if we get NULL from the service (i.e., no records found
            // matching the given ID).
            if (cartonDetailsViewModel.Carton == null)
            {
                return HttpNotFound();
            }

            return View(cartonDetailsViewModel);
        }

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
        public ActionResult Create([Bind(Include = "Id,CartonNumber")] Data.EntityModels.Carton carton)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //if (ModelState.IsValid)
            //{
            //    db.Cartons.Add(carton);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(carton);
        }

        // GET: Carton/Edit/5
        public ActionResult Edit(int? id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var carton = db.Cartons
            //    .Where(c => c.Id == id)
            //    .Select(c => new CartonViewModel()
            //    {
            //        //Id = c.Id,
            //        //CartonNumber = c.CartonNumber
            //    })
            //    .SingleOrDefault();
            //if (carton == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(carton);
        }

        // POST: Carton/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CartonNumber")] CartonViewModel cartonViewModel)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //if (ModelState.IsValid)
            //{
            //    //var carton = db.Cartons.Find(cartonViewModel.Id);
            //    //carton.CartonNumber = cartonViewModel.CartonNumber;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(cartonViewModel);
        }

        // GET: Carton/Delete/5
        public ActionResult Delete(int? id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Data.EntityModels.Carton carton = db.Cartons.Find(id);
            //if (carton == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(carton);
        }

        // POST: Carton/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Data.EntityModels.Carton carton = db.Cartons.Find(id);
            db.Cartons.Remove(carton);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddEquipment(int? id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //var carton = db.Cartons
            //    .Where(c => c.Id == id)
            //    .Select(c => new CartonDetailsViewModelOld()
            //    {
            //        CartonNumber = c.CartonNumber,
            //        CartonId = c.Id
            //    })
            //    .SingleOrDefault();

            //if (carton == null)
            //{
            //    return HttpNotFound();
            //}

            //var equipment = db.Equipments
            //    .Where(e => !db.CartonDetails.Where(cd => cd.CartonId == id).Select(cd => cd.EquipmentId).Contains(e.Id) )
            //    .Select(e => new EquipmentViewModel()
            //    {
            //        Id = e.Id,
            //        ModelType = e.ModelType.TypeName,
            //        SerialNumber = e.SerialNumber
            //    })
            //    .ToList();

            //carton.Equipment = equipment;
            //return View(carton);
        }

        public ActionResult AddEquipmentToCarton([Bind(Include = "CartonId,EquipmentId")] AddEquipmentViewModel addEquipmentViewModel)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //if (ModelState.IsValid)
            //{
            //    var carton = db.Cartons
            //        .Include(c => c.CartonDetails)
            //        .Where(c => c.Id == addEquipmentViewModel.CartonId)
            //        .SingleOrDefault();
            //    if (carton == null)
            //    {
            //        return HttpNotFound();
            //    }
            //    var equipment = db.Equipments
            //        .Where(e => e.Id == addEquipmentViewModel.EquipmentId)
            //        .SingleOrDefault();
            //    if (equipment == null)
            //    {
            //        return HttpNotFound();
            //    }
            //    var detail = new Data.EntityModels.CartonDetail()
            //    {
            //        Carton = carton,
            //        Equipment = equipment
            //    };
            //    carton.CartonDetails.Add(detail);
            //    db.SaveChanges();
            //}
            //return RedirectToAction("AddEquipment", new { id = addEquipmentViewModel.CartonId });
        }

        public ActionResult ViewCartonEquipment(int? id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var carton = db.Cartons
            //    .Where(c => c.Id == id)
            //    .Select(c => new CartonDetailsViewModelOld()
            //    {
            //        CartonNumber = c.CartonNumber,
            //        CartonId = c.Id,
            //        Equipment = c.CartonDetails
            //            .Select(cd => new EquipmentViewModel()
            //            {
            //                Id = cd.EquipmentId,
            //                ModelType = cd.Equipment.ModelType.TypeName,
            //                SerialNumber = cd.Equipment.SerialNumber
            //            })
            //    })
            //    .SingleOrDefault();
            //if (carton == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(carton);
        }

        public ActionResult RemoveEquipmentOnCarton([Bind(Include = "CartonId,EquipmentId")] RemoveEquipmentViewModel removeEquipmentViewModel)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //if (ModelState.IsValid)
            //{
            //    //Remove code here
            //}
            //return RedirectToAction("ViewCartonEquipment", new { id = removeEquipmentViewModel.CartonId });
        }
    }
}
