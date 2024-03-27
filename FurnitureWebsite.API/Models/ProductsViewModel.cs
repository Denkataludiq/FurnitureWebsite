using FurnitureWebsite.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureWebsite.Models
{
    public class ProductsViewModel
    {
        public List<CategoriesViewModel> Categories { get; set; }
    }
}
