using Microsoft.AspNetCore.Mvc;
using Shop_mvc_pv421.Data;

namespace Shop_mvc_pv421.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            ShopDbContext ctx = new();

            var model = ctx.Products.ToList();

            return View(model);
        }
    }
}
