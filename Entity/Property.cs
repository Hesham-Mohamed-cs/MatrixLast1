using System.ComponentModel.DataAnnotations.Schema;

namespace MatrixTask.Entity
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
