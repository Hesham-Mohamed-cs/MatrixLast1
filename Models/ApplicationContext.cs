using MatrixTask.Entity;
using Microsoft.EntityFrameworkCore;

namespace MatrixTask.Models
{
    public class ApplicationContext :DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }
        public ApplicationContext( DbContextOptions<ApplicationContext> options ) : base(options)
        {
            
        }
    }
}
