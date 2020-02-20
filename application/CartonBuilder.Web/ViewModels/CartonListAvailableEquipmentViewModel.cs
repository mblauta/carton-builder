using CartonBuilder.Common.Models;
using System.Collections.Generic;

namespace CartonBuilder.Web.ViewModels
{
    public class CartonListAvailableEquipmentViewModel
    {
        public Carton Carton { get; set; }

        public List<Equipment> EquipmentList { get; set; }
    }
}