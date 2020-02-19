using System.Collections.Generic;
using CartonBuilder.Models;

namespace CartonBuilder.Web.ViewModels
{
    public class CartonListAddedEquipmentViewModel
    {
        public Carton Carton { get; set; }

        public List<Equipment> EquipmentList { get; set; }
    }
}