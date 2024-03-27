using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureWebsite.Services.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string BaseCategoryName { get; set; }
        public byte[] Picture { get; set; }
    }
}
