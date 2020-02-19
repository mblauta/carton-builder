using CartonBuilder.Models;
using System.Collections.Generic;
using System.Linq;

namespace CartonBuilder.Data.Services
{
    public class EquipmentService
    {
        /// <summary>
        /// Gets the equipment that matches the given ID.
        /// </summary>
        /// <param name="equipmentId">ID of equipment to look for.</param>
        /// <returns>
        /// Returns an equipment that matches the given ID. If the ID is not found
        /// in the data store, NULL is returned.
        /// </returns>
        public Equipment GetEquipment(int equipmentId)
        {
            using (var warehouseContext = new WarehouseContext())
            {
                Equipment equipment = (from e in warehouseContext.Equipments
                                       join mt in warehouseContext.ModelTypes on e.ModelTypeId equals mt.Id into tmp
                                       from mt in tmp.DefaultIfEmpty()
                                       where e.Id == equipmentId
                                       select new Equipment()
                                       {
                                           Id = e.Id,
                                           SerialNumber = e.SerialNumber,
                                           ModelType = new ModelType()
                                           {
                                               Id = mt.Id,
                                               TypeName = mt.TypeName
                                           }
                                       })
                                      .SingleOrDefault();
                return equipment;
            }
        }

        /// <summary>
        /// Lists all the equipment currently in the data store that can be added to the carton.
        /// </summary>
        /// <returns>Returns a list of equipment.</returns>
        public List<Equipment> ListAvailableEquipmentForCarton(int cartonId)
        {
            using (var warehouseContext = new WarehouseContext())
            {
                // Retrieve IDs of all equipment already in the carton...
                IQueryable<int> equipmentIdsInCarton = warehouseContext.CartonDetails
                                                          .Where(cd => cd.CartonId == cartonId)
                                                          .Select(cd => cd.EquipmentId);

                List<Equipment> equipmentList = (from e in warehouseContext.Equipments
                                                 join mt in warehouseContext.ModelTypes on e.ModelTypeId equals mt.Id into tmp
                                                 from mt in tmp.DefaultIfEmpty()
                                                 where !equipmentIdsInCarton.Contains(e.Id)
                                                 select new Equipment()
                                                 {
                                                     Id = e.Id,
                                                     SerialNumber = e.SerialNumber,
                                                     ModelType = new ModelType()
                                                     {
                                                         Id = mt.Id,
                                                         TypeName = mt.TypeName
                                                     }
                                                 })
                                                .ToList();

                return equipmentList;
            }
        }

        /// <summary>
        /// Lists all the equipment added to the carton specified.
        /// </summary>
        /// <returns>Returns a list of equipment.</returns>
        public List<Equipment> ListAddedEquipmentForCarton(int cartonId)
        {
            using (var warehouseContext = new WarehouseContext())
            {
                // Retrieve IDs of all equipment already in the carton...
                IQueryable<int> equipmentIdsInCarton = warehouseContext.CartonDetails
                                                          .Where(cd => cd.CartonId == cartonId)
                                                          .Select(cd => cd.EquipmentId);

                List<Equipment> equipmentList = (from e in warehouseContext.Equipments
                                                 join mt in warehouseContext.ModelTypes on e.ModelTypeId equals mt.Id into tmp
                                                 from mt in tmp.DefaultIfEmpty()
                                                 where equipmentIdsInCarton.Contains(e.Id)
                                                 select new Equipment()
                                                 {
                                                     Id = e.Id,
                                                     SerialNumber = e.SerialNumber,
                                                     ModelType = new ModelType()
                                                     {
                                                         Id = mt.Id,
                                                         TypeName = mt.TypeName
                                                     }
                                                 })
                                                .ToList();

                return equipmentList;
            }
        }
    }
}
