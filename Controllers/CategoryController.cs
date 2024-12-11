using Estore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estore.Controllers
{
    [ApiController]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly IRepository<ProductType> repository;
        public CategoryController(IRepository<ProductType> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult>  GetAllCategory()
        {
            var result = await repository.GetAll();
            var category = result.Select(x=>new ProductType() 
            { Id=x.Id,TypeName=x.TypeName}).ToList();
            return Ok(category); 
        }
    }
}
