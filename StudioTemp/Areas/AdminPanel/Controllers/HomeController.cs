using Microsoft.AspNetCore.Mvc;

namespace StudioTemp.Areas.AdminPanel.Controllers
{
    [Area("Adminpanel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
