using CartonBuilder.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CartonBuilder.Data.Services
{
    public class CartonService
    {
        /// <summary>
        /// Lists all the cartons currently in the database.
        /// </summary>
        /// <returns>Returns a list of cartons.</returns>
        public List<Carton> ListCartons()
        {
            using (var cartonContext = new CartonContext())
            {
                List<Carton> cartons = cartonContext.Cartons
                                         .Select(c => new Carton()
                                         {
                                             Id = c.Id,
                                             CartonNumber = c.CartonNumber
                                         })
                                         .ToList();
                return cartons;
            }
        }

        /// <summary>
        /// Gets the carton that matches the given ID.
        /// </summary>
        /// <param name="cartonId">ID of carton to look for.</param>
        /// <returns>
        /// Returns a carton that matches the given ID. If the ID is not found
        /// in the database, NULL is returned.
        /// </returns>
        public Carton GetCarton(int cartonId)
        {
            using (var cartonContext = new CartonContext())
            {
                Carton carton = cartonContext.Cartons
                                    .Where(c => c.Id == cartonId)
                                    .Select(c => new Carton()
                                    {
                                        Id = c.Id,
                                        CartonNumber = c.CartonNumber
                                    })
                                    .SingleOrDefault();
                return carton;
            }
        }

        /// <summary>
        /// Adds a new carton to the database.
        /// </summary>
        /// <param name="carton">The carton to be added to the database.</param>
        /// <returns>Returns the ID of the newly added carton.</returns>
        public int AddCarton(Carton carton)
        {
            // Throw exception if no carton was provided.
            if (carton == null)
            {
                throw new ArgumentNullException("carton", "Carton is required but was not provided.");
            }

            using (var cartonContext = new CartonContext())
            {
                var cartonEntityModel = new EntityModels.Carton()
                {
                    Id = carton.Id,
                    CartonNumber = carton.CartonNumber
                };

                var newCarton = cartonContext.Cartons.Add(cartonEntityModel);
                cartonContext.SaveChanges();

                return newCarton.Id;
            }
        }
    }
}
