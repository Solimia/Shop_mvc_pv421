using System.Diagnostics;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_mvc_pv421.Models;

namespace Shop_mvc_pv421.Controllers
{
    public class HomeController : Controller

    {
        private readonly ShopDbContext ctx;

        public HomeController(ShopDbContext ctx)
        {
            this.ctx = ctx;
        }
  
        public IActionResult Index()
        {
            var products = ctx.Products.Include(x => x.Category).ToList();

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
