using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartonBuilder.Data.EntityModels
{
    [Table("Carton")]
    public partial class Carton
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Carton()
        {
            CartonDetails = new HashSet<CartonDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CartonNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<CartonDetail> CartonDetails { get; set; }
    }
}
