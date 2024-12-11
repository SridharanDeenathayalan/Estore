using Estore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Estore.Controllers
{
    [ApiController]
    [Route("api/Brand")]
    public class BrandController : Controller
    {
        private readonly IRepository<ProductBrand> repository;
        public BrandController(IRepository<ProductBrand> repository)
        {
            this.repository = repository;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            var result = await repository.GetAll();
            var brand = result.Select(x => new ProductBrand()
            {
                Id = x.Id,
                BrandName = x.BrandName,

            }).ToList();
            return Ok(brand);
        }
    }
}
