using System.ComponentModel;

namespace CartonBuilder.Common.Models
{
    public class ModelType
    {
        [DisplayName("Model ID")]
        public int Id { get; set; }

        [DisplayName("Model Type Name")]
        public string TypeName { get; set; }
    }
}
