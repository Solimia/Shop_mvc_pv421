using Microsoft.AspNetCore.Mvc;

namespace Shop_mvc_pv421.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
