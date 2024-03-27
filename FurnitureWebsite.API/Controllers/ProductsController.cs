using FurnitureWebsite.Models;
using FurnitureWebsite.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureWebsite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

       [HttpGet]
        public async Task<IActionResult> Products(string searchText = null)
        {
            ProductsViewModel model = new();
            model.Categories = await this.productsService.GetAllAsync(searchText);
            return View(model);
        }
    }
}
