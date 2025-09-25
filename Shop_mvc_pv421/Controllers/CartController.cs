using Microsoft.AspNetCore.Mvc;

namespace Shop_mvc_pv421.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add (int id)
        {

            List<int> ids = new List<int>();

            ids.Add(id);

            HttpContext.Session.SetString("UserCart", id.ToString());

            return View();
        }

        public IActionResult Remove()
        {
            return View();
        }
    }
}
