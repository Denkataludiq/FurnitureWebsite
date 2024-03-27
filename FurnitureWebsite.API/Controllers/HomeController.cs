using FurnitureWebsite.Models;
using FurnitureWebsite.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController (IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();
            model.ProductItems = await this.productsService.GetAllProductsAsync();
            model.ProductDiscountItems = await this.productsService.GetAllProductsDiscountAsync();
            return View(model);
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
