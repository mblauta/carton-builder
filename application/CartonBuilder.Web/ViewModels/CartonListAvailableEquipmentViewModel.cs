using System.Collections.Generic;
using CartonBuilder.Models;

namespace CartonBuilder.Web.ViewModels
{
    public class CartonListAvailableEquipmentViewModel
    {
        public Carton Carton { get; set; }

        public List<Equipment> EquipmentList { get; set; }
    }
}