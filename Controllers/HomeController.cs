// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

namespace ASAG_ILIK_nvOM.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return RedirectToAction("Register", "Index"); // Burada "Register/Index" sayfasına doğrudan yönlendirme yapılıyor.
        }

        public IActionResult Login()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
