using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estore.Model
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Product> ProductList { get; set; }
    }
}