using FurnitureWebsite.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureWebsite.Services.Contracts
{
    public interface IProductsService
    {
        Task<List<ProductViewModel>> GetAllProductsAsync();
        Task<List<CategoriesViewModel>> GetAllAsync(string searchText = null);
        Task<List<ProductViewModel>> GetAllProductsDiscountAsync();
        Task<ProductItemViewModel>GetAsync(int id);
        void SaveReservationDetailsAsync(string name, string email, string phone, int productID);
    }
}
