using AutoMapper;
using Estore.Model;
using Estore.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Estore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;
        private readonly string _apiurl;
        public ProductController(IRepository<Product> repository,IMapper mapper,IConfiguration configuration)
        {
            this.repository = repository;
            this.mapper = mapper;
            _apiurl = configuration.GetValue<string>("MySettings:ApiUrl");
        }



        //[HttpPost]
        //public async Task<IActionResult> create([FromForm] ProductDTO p, [FromForm] IFormFile image)
        //{
        //    try
        //    {
        //        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        //        if (!Directory.Exists(folderPath))
        //        {
        //            Directory.CreateDirectory(folderPath);
        //        }
        //        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
        //        var filePath = Path.Combine(folderPath, fileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await image.CopyToAsync(stream);
        //        }
        //        var relativePath = $"/images/{fileName}";
        //        var product = mapper.Map<ProductDTO,Product>(p);
        //        product.PictureUrl = relativePath;
        //        await repository.Add(product);

        //        return Ok(product);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ex);
        //    }
            
        //}

        [HttpGet]
        public async Task<IActionResult> GetProducts(string? searchtext=null,string? sortcolumn=null,string? sortorder=null,int pageindex = 1, int pagesize =6,int brandid=0,int typeid=0)
         {
            try
            {
                var products = await repository.GetAll(p => p.ProductBrand, p => p.ProductType);
                var result = products.Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    PictureUrl = _apiurl + x.PictureUrl,
                    MadeInIndia = x.MadeInIndia,
                    PriceSegment = x.PriceSegment,
                    ProductBrandId = x.ProductBrand.Id,
                    ProductTypeId = x.ProductType.Id

                }).ToList();

                

                if (!string.IsNullOrEmpty(searchtext))
                {
                    result=result.Where(p=>p.Name.Contains(searchtext, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if(!string.IsNullOrEmpty(sortorder) & !string.IsNullOrEmpty(sortcolumn))
                {
                    result = sortorder == "desc" ? result.OrderByDescending(s => s.GetType().GetProperty(sortcolumn).GetValue(s, null)).ToList():

                      result.OrderBy(c => c.GetType().GetProperty(sortcolumn).GetValue(c, null)).ToList();
                }

                if (brandid != 0) { result=result.Where(b=>b.ProductBrandId==brandid).ToList(); }

                if (typeid != 0) { result=result.Where(t => t.ProductTypeId == typeid).ToList(); }

                result=result.Skip((pageindex - 1) * pagesize)
                       .Take(pagesize)
                       .ToList();
                var PaginationResponse = new PaginationResponse<Product>() { pageindex=pageindex,
                    pagesize=pagesize,
                    count=result.Count,
                    data=result};
                return Ok(PaginationResponse);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
    }
}
