using CartonBuilder.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}
