using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_mvc_pv421.Data;
using Shop_mvc_pv421.Data.Entities;

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

            var model = ctx.Products.Include(x => x.Category).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ctx.Products.Add(product);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = ctx.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ctx.Products.Update(product);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = ctx.Products.Find(id);
            if(product == null) return NotFound();
            
            ctx.Products.Remove(product);
            ctx.SaveChanges();

            return RedirectToAction("Index") ;
        }
    }
}
