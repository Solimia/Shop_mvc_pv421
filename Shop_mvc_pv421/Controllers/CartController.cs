using Microsoft.AspNetCore.Mvc;
using Shop_mvc_pv421.Extensions;

namespace Shop_mvc_pv421.Controllers
{
    public class CartController : Controller
    {
        //get 
        public ActionResult Index()
        {
            var existingIds = HttpContext.Session.Get<List<int>>("CartItem") ?? new List<int>();

            return View(existingIds);
        }

        public ActionResult Add (int id)
        {
            var existingIds = HttpContext.Session.Get<List<int>>("CartItems");

            List<int> ids = existingIds ?? new();

            ids.Add(id);

            HttpContext.Session.Set("CartItems", ids);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Remove()
        {
            return View();
        }
    }
}
