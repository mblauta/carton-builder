using System.ComponentModel;

namespace CartonBuilder.Models
{
    public class CartonDetail
    {
        [DisplayName("Carton Detail ID")]
        public int Id { get; set; }

        [DisplayName("Carton ID")]
        public int CartonId { get; set; }

        [DisplayName("Equipment ID")]
        public int EquipmentId { get; set; }
    }
}
