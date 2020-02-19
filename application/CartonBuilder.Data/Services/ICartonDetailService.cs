using CartonBuilder.Models;

namespace CartonBuilder.Data.Services
{
    public interface ICartonDetailService
    {
        /// <summary>
        /// Adds a new Carton Detail to the data store.
        /// </summary>
        /// <param name="cartonDetail">The carton detail to be added.</param>
        /// <returns>Returns the ID of the newly added carton detail.</returns>
        int AddCartonDetail(CartonDetail cartonDetail);

        /// <summary>
        /// Removes the Carton Detail provided from the data store.
        /// </summary>
        /// <param name="cartonDetail">The carton detail to be removed.</param>
        void RemoveCartonDetail(CartonDetail cartonDetail);

        /// <summary>
        /// Adds an equipment to the carton specified.
        /// </summary>
        /// <param name="cartonId">The ID of the carton to add to.</param>
        /// <param name="equipmentId">The ID of the equipment being added.</param>
        /// <returns>Returns the ID of the newly created carton-equipment lookup record.</returns>
        int AddEquipmentToCarton(int cartonId, int equipmentId);

        /// <summary>
        /// Removes an equipment from the carton specified.
        /// </summary>
        /// <param name="cartonId">The ID of the carton to remove from.</param>
        /// <param name="equipmentId">The ID of the equipment being removed.</param>
        void RemoveEquipmentFromCarton(int cartonId, int equipmentId);
    }
}
