using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureWebsite.Services.Models
{
    public class CategoriesViewModel
    {
        public string Name { get; set; }
        public List<ProductViewModel> Items { get; set; }
    }
}
