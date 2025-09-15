using Microsoft.AspNetCore.Mvc;
using Shop_mvc_pv421.Data;

namespace Shop_mvc_pv421.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext ctx;

        public ProductsController(ShopDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {

            var model = ctx.Products.ToList();

            return View(model);
        }
    }
}
