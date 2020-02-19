using System.ComponentModel;

namespace CartonBuilder.Models
{
    public class ModelType
    {
        [DisplayName("Model ID")]
        public int Id { get; set; }

        [DisplayName("Model Type Name")]
        public string TypeName { get; set; }
    }
}
