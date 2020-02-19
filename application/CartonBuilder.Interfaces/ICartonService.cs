using CartonBuilder.Models;
using System.Collections.Generic;

namespace CartonBuilder.Interfaces
{
    public interface ICartonService
    {
        /// <summary>
        /// Lists all the cartons currently in the data store.
        /// </summary>
        /// <returns>Returns a list of cartons.</returns>
        List<Carton> ListCartons();

        /// <summary>
        /// Gets the carton that matches the given ID.
        /// </summary>
        /// <param name="cartonId">ID of carton to look for.</param>
        /// <returns>
        /// Returns a carton that matches the given ID. If the ID is not found
        /// in the data store, NULL is returned.
        /// </returns>
        Carton GetCarton(int cartonId);

        /// <summary>
        /// Adds a new carton to the data store.
        /// </summary>
        /// <param name="carton">The carton to be added to the data store.</param>
        /// <returns>Returns the ID of the newly added carton.</returns>
        int AddCarton(Carton carton);

        /// <summary>
        /// Updates the carton details for a given ID.
        /// </summary>
        /// <param name="carton">The carton details to save.</param>
        /// <remarks>
        /// Note that the value passed in the 'Id' field will be used to search for the corresponding
        /// record to update.
        /// </remarks>
        void UpdateCarton(Carton carton);

        /// <summary>
        /// Removes a carton matching the ID provided from the data store.
        /// </summary>
        /// <param name="cartonId">ID of carton to remove.</param>
        void RemoveCarton(int cartonId);
    }
}
