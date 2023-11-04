using System.ComponentModel.DataAnnotations.Schema;

namespace MatrixTask.Entity
{
    public class PropertyValue
    {
        public int PropertyValueId { get; set; }
        [ForeignKey("Property")]
        public int? PropertyId { get; set; }
        public Property? Property { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public string Value { get; set; }
    }
}
