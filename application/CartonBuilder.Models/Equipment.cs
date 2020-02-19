using System.ComponentModel;

namespace CartonBuilder.Models
{
    public class Equipment
    {
        [DisplayName("Equipment ID")]
        public int Id { get; set; }

        [DisplayName("Equipment Serial Number")]
        public string SerialNumber { get; set; }

        [DisplayName("Equipment Model Type")]
        public ModelType ModelType { get; set; }
    }
}
