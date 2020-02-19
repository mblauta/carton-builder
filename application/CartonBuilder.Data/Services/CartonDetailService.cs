using CartonBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CartonBuilder.Data.Services
{
    public class CartonDetailService
    {
        /// <summary>
        /// Adds a new Carton Detail to the data store.
        /// </summary>
        /// <param name="cartonDetail">The carton detail to be added.</param>
        /// <returns>Returns the ID of the newly added carton detail.</returns>
        public int AddCartonDetail(CartonDetail cartonDetail)
        {
            // Throw exception if no carton detail was provided. Nothing to do here.
            if (cartonDetail == null)
            {
                throw new ArgumentNullException("cartonDetail", "Carton Detail is required but was not provided.");
            }

            using (var warehouseContext = new WarehouseContext())
            {
                var cartonDetailEntityModel = new EntityModels.CartonDetail()
                {
                    CartonId = cartonDetail.CartonId,
                    EquipmentId = cartonDetail.EquipmentId
                };
                EntityModels.CartonDetail newCartonDetailEntityModel = warehouseContext.CartonDetails.Add(cartonDetailEntityModel);
                warehouseContext.SaveChanges();

                return newCartonDetailEntityModel.Id;
            }
        }

        /// <summary>
        /// Removes the Carton Detail provided from the data store.
        /// </summary>
        /// <param name="cartonDetail">The carton detail to be removed.</param>
        public void RemoveCartonDetail(CartonDetail cartonDetail)
        {
            // Throw exception if no carton detail was provided. Nothing to do here.
            if (cartonDetail == null)
            {
                throw new ArgumentNullException("cartonDetail", "Carton Detail is required but was not provided.");
            }

            using (var warehouseContext = new WarehouseContext())
            {
                // Retrieve the carton detail having the carton and equipment provided...
                EntityModels.CartonDetail cartonDetailEntityModel = warehouseContext.CartonDetails
                                                                       .Where(cd => cd.CartonId == cartonDetail.CartonId 
                                                                                 && cd.EquipmentId == cartonDetail.EquipmentId)
                                                                       .FirstOrDefault();

                // No harm done. Record does not exist anyway.
                if (cartonDetailEntityModel == null) return;

                warehouseContext.CartonDetails.Remove(cartonDetailEntityModel);
                warehouseContext.SaveChanges();
            }
        }

        #region Helper Methods

        /// <summary>
        /// Adds an equipment to the carton specified.
        /// </summary>
        /// <param name="cartonId">The ID of the carton to add to.</param>
        /// <param name="equipmentId">The ID of the equipment being added.</param>
        /// <returns>Returns the ID of the newly created carton-equipment lookup record.</returns>
        public int AddEquipmentToCarton(int cartonId, int equipmentId)
        {
            var cartonDetail = new CartonDetail()
            {
                CartonId = cartonId,
                EquipmentId = equipmentId
            };
            return AddCartonDetail(cartonDetail);
        }

        /// <summary>
        /// Removes an equipment from the carton specified.
        /// </summary>
        /// <param name="cartonId">The ID of the carton to remove from.</param>
        /// <param name="equipmentId">The ID of the equipment being removed.</param>
        public void RemoveEquipmentFromCarton(int cartonId, int equipmentId)
        {
            var cartonDetail = new CartonDetail()
            {
                CartonId = cartonId,
                EquipmentId = equipmentId
            };
            RemoveCartonDetail(cartonDetail);
        }

        #endregion Helper Methods
    }
}
