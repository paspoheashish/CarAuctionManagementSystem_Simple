using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
