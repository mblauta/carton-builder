using CartonBuilder.Common.Models;
using System.Collections.Generic;

namespace CartonBuilder.Common.Interfaces
{
    public interface IEquipmentService
    {
        /// <summary>
        /// Gets the equipment that matches the given ID.
        /// </summary>
        /// <param name="equipmentId">ID of equipment to look for.</param>
        /// <returns>
        /// Returns an equipment that matches the given ID. If the ID is not found
        /// in the data store, NULL is returned.
        /// </returns>
        Equipment GetEquipment(int equipmentId);

        /// <summary>
        /// Lists all the equipment currently in the data store that can be added to the carton.
        /// </summary>
        /// <returns>Returns a list of equipment.</returns>
        List<Equipment> ListAvailableEquipmentForCarton(int cartonId);

        /// <summary>
        /// Lists all the equipment added to the carton specified.
        /// </summary>
        /// <returns>Returns a list of equipment.</returns>
        List<Equipment> ListAddedEquipmentForCarton(int cartonId);
    }
}
