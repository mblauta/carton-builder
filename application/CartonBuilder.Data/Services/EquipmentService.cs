using CartonBuilder.Models;
using System.Collections.Generic;
using System.Linq;

namespace CartonBuilder.Data.Services
{
    public class EquipmentService
    {
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

                List<Equipment> equipmentList = warehouseContext.Equipments
                                                   .Where(e => !equipmentIdsInCarton.Contains(e.Id))
                                                   .Select(e => new Equipment()
                                                   {
                                                       Id = e.Id,
                                                       ModelType = e.ModelType.TypeName,
                                                       SerialNumber = e.SerialNumber
                                                   })
                                                   .ToList();

                return equipmentList;
            }
        }
    }
}
