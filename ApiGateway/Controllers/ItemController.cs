using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
