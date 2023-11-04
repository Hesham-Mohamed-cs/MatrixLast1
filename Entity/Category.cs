using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrixTask.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; }
        public List<Product> Products { get; set; }
        public List<Property> Properties { get; set; }
    }
}
