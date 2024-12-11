using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estore.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public bool MadeInIndia { get; set; }
        public string PriceSegment { get; set; }
        public ProductType ProductType { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        [ForeignKey("ProductBrand")]
        public int ProductBrandId { get; set; }
    }
}
