using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estore.Model
{
    //[Route("Error/{code}")]
    public class ErrorController : Controller
    {
        [NonAction]
        public IActionResult Index(int statuscode)
        {
            switch (statuscode)
            {
                case 404:
                    return View("NotFound");
                case 500:
                    return View("ServerError");
                default:
                    return View("GenericError");
            }
        }
    }
}
