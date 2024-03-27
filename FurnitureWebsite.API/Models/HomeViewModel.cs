using FurnitureWebsite.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureWebsite.Models
{
    public class HomeViewModel
    {
        public List<ProductViewModel> ProductItems { get; set; }
        public List<ProductViewModel> ProductDiscountItems { get; set; }
            
    }
}
