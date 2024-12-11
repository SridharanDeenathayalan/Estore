using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estore.Model
{
    public class ProductBrand
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public virtual ICollection<Product> ProductList { get; set; }
    }
}