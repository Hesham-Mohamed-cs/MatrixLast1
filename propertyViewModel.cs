using System.ComponentModel.DataAnnotations.Schema;

namespace MatrixTask
{
    public class propertyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    
    }
}
