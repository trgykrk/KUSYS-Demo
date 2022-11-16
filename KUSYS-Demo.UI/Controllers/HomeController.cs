using KUSYS_Demo.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.UI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
