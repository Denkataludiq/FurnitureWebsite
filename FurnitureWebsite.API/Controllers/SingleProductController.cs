using FurnitureWebsite.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureWebsite.Controllers
{
    public class SingleProductController : Controller
    {
        private readonly IProductsService productsService;

        public SingleProductController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        public async Task<IActionResult> SingleProduct(int ID)
        {
            var model = await this.productsService.GetAsync(ID);
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(string name, string email, string phone, int productID)
        {
             this.productsService.SaveReservationDetailsAsync(name, email, phone, productID);
            return RedirectToAction("SingleProduct", new {ID = productID });
        }
    }
}
