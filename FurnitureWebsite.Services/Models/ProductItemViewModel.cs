using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureWebsite.Services.Models
{
    public class ProductItemViewModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Characteristic { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreationTime { get; set; }
        public byte[] BasePicture { get; set; }
        public List<Byte[]> Pictures { get; set; }
    }

}
