using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop_mvc_pv421.Data;
using Shop_mvc_pv421.Data.Entities;
using Shop_mvc_pv421.Extensions;
using Shop_mvc_pv421.Models;


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
            SetCategoriesToViewBag();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                SetCategoriesToViewBag();
                return View();
            }

            ctx.Products.Add(product);
            ctx.SaveChanges();

            //TempData[WebConstants.ToastMessage] = new ToastModel("Product created successfully!");
            //ViewBag.ToastMessage = "Product created succerst";

            TempData.Set(WebConstants.ToastMessage, new ToastModel("Product created successfully!"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = ctx.Products.Find(id);
            if (product == null) return NotFound();

            SetCategoriesToViewBag();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                SetCategoriesToViewBag();
                return View();
            }
            ctx.Products.Update(product);
            ctx.SaveChanges();

            TempData.Set(WebConstants.ToastMessage, new ToastModel("Product update successfully!"));
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = ctx.Products.Find(id);
            if (product == null) return NotFound();
            
            ctx.Products.Remove(product);
            ctx.SaveChanges();

            TempData.Set(WebConstants.ToastMessage, new ToastModel("Product delete successfully!", ToastType.danger));

            return RedirectToAction("Index") ;
        }

        private void SetCategoriesToViewBag()
        {
            var categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");

            ViewBag.Categories = categories;
        }
    }
}
