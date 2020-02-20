using CartonBuilder.Common.Models;
using System.Collections.Generic;

namespace CartonBuilder.Web.ViewModels
{
    public class CartonListAddedEquipmentViewModel
    {
        public Carton Carton { get; set; }

        public List<Equipment> EquipmentList { get; set; }
    }
}