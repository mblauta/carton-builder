using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CartonBuilder.Models
{
    public class Carton
    {
        [DisplayName("Carton ID")]
        public int Id { get; set; }

        [DisplayName("Carton Number")]
        [Required]
        [StringLength(50)]
        public string CartonNumber { get; set; }
    }
}
