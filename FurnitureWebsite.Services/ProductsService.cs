using FurnitureWebsite.Services.Contracts;
using FurnitureWebsite.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureWebsite.Services
{
    public class ProductsService : IProductsService
    {
        private const string ConnectionString = "Data Source = DESKTOP-SOJHTJB\\SQLEXPRESS; Initial Catalog = warehouse; Integrated Security = SSPI; MultipleActiveResultSets = true; Connection Timeout = 10; TrustServerCertificate= true;";

        public async Task<List<CategoriesViewModel>> GetAllAsync(string searchText = null)
        {
            // Connection and SQL strings
            string whereClause = string.IsNullOrWhiteSpace(searchText) ? string.Empty : $"WHERE p.Name like '%{searchText}%' or c.Name like '%{searchText}%'";
            string SQL = $@"SELECT p.ID, p.Name, p.Price, c.Name AS CategoryName, b.Name as BaseCategoryName, pic.Picture, p.Discount FROM Products p
                    JOIN Categories c ON c.ID = p.CategoryID JOIN Base_Categories b ON b.ID = p.BaseCategoryID
                    JOIN Product_Picture pic ON (pic.ProductID = p.ID and pic.IsDefault = 1) {whereClause}";

            // create a connection object
            SqlConnection conn = new SqlConnection(ConnectionString);

            // create command object
            SqlCommand cmd = new SqlCommand(SQL, conn);

            // open connection
            conn.Open();

            // call command's ExcuteReader
            SqlDataReader reader = cmd.ExecuteReader();
            var result = new List<ProductViewModel>();
            try
            {
                while (reader.Read())
                {
                    var model = new ProductViewModel
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        CategoryName = reader.GetString(3),
                        BaseCategoryName = reader.GetString(4),
                        Picture = reader.GetValue(5) as byte[],
                        Discount = reader.GetDecimal(6)
                    };
                    result.Add(model);
                }
            }

            finally
            {
                // close reader and connection
                reader.Close();
                conn.Close();
            }
            var ViewModel = new List<CategoriesViewModel>();
            foreach (var item in result.GroupBy(r => r.BaseCategoryName))
            {
                var Model = new CategoriesViewModel { Name = item.Key, Items = item.ToList() };
                ViewModel.Add(Model);

            }
            return ViewModel;
        }


        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            // Connection and SQL strings
            string SQL = @"SELECT Top 4 p.ID, p.Name, p.Price, c.Name, pic.Picture AS CategoryName FROM Products p
                    JOIN Categories c ON c.ID = p.CategoryID JOIN Product_Picture pic ON (pic.ProductID = p.ID and pic.IsDefault = 1) WHERE p.Discount <= 0";

            // create a connection object
            SqlConnection conn = new SqlConnection(ConnectionString);

            // create command object
            SqlCommand cmd = new SqlCommand(SQL, conn);

            // open connection
            conn.Open();

            // call command's ExcuteReader
            SqlDataReader reader = cmd.ExecuteReader();
            var result = new List<ProductViewModel>();
            try
            {
                while (reader.Read())
                {
                    var model = new ProductViewModel
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        CategoryName = reader.GetString(3),
                        Picture = reader.GetValue(4) as byte[]
                    };
                    result.Add(model);
                }
            }

            finally
            {
                // close reader and connection
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public async Task<List<ProductViewModel>> GetAllProductsDiscountAsync()
        {
            // Connection and SQL strings
            string SQL = @"SELECT Top 4 p.ID, p.Name, p.Price, p.Discount, c.Name, pic.Picture AS CategoryName FROM Products p
                    JOIN Categories c ON c.ID = p.CategoryID JOIN Product_Picture pic ON (pic.ProductID = p.ID and pic.IsDefault = 1) WHERE p.Discount > 0";

            // create a connection object
            SqlConnection conn = new SqlConnection(ConnectionString);

            // create command object
            SqlCommand cmd = new SqlCommand(SQL, conn);

            // open connection
            conn.Open();

            // call command's ExcuteReader
            SqlDataReader reader = cmd.ExecuteReader();
            var result = new List<ProductViewModel>();
            try
            {
                while (reader.Read())
                {
                    var model = new ProductViewModel
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        Discount = reader.GetDecimal(3),
                        CategoryName = reader.GetString(4),
                        Picture = reader.GetValue(5) as byte[]
                    };
                    result.Add(model);
                }
            }

            finally
            {
                // close reader and connection
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public async Task<ProductItemViewModel> GetAsync(int id)
        {
            // Connection and SQL strings
            string SQL = $@"SELECT p.ID 
                  ,p.Name
                  ,p.Description
                  ,p.Characteristic
                  ,p.Size
                  ,p.Price
                  ,c.Name AS CategoryName
                  ,p.Discount
                  ,p.CreationTime
                  ,pic.Picture
                  FROM Products p
                    JOIN Categories c ON c.ID = p.CategoryID
                    JOIN Product_Picture pic ON pic.ProductID = p.ID WHERE pic.IsDefault = 1
            and p.ID = {id}";

            // create a connection object
            SqlConnection conn = new SqlConnection(ConnectionString);

            // create command object
            SqlCommand cmd = new SqlCommand(SQL, conn);

            // open connection
            conn.Open();

            // call command's ExcuteReader
            SqlDataReader reader = cmd.ExecuteReader();
            var result = new ProductItemViewModel();
            try
            {
                while (reader.Read())
                {
                     result = new ProductItemViewModel
                     {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Characteristic = reader.GetString(3),
                        Size = reader.GetString(4),
                        Price = reader.GetDecimal(5),
                        CategoryName = reader.GetString(6),
                        Discount = reader.GetDecimal(7),
                        CreationTime = reader.GetDateTime(8),
                        BasePicture = (byte[])reader.GetValue(9)

                     };
                    
                }
            }

            finally
            {
                // close reader and connection
                reader.Close();
                conn.Close();
            }

            this.GetPictures(result);
            return result;

        }

        public void SaveReservationDetailsAsync(string name, string email, string phone, int productID)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = $"INSERT INTO Reservation_Details (Name, Email, Number, ProductID) VALUES ('{name}', '{email}', '{phone}', {productID})";

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void GetPictures(ProductItemViewModel model)
        {
            // Connection and SQL strings
            string SQL = $@"SELECT pic.Picture
                  FROM Products p
                    JOIN Categories c ON c.ID = p.CategoryID 
JOIN Product_Picture pic on pic.ProductID = p.ID
            WHERE p.ID = {model.ID} and pic.IsDefault = 0";

            // create a connection object
            SqlConnection conn = new SqlConnection(ConnectionString);

            // create command object
            SqlCommand cmd = new SqlCommand(SQL, conn);

            // open connection
            conn.Open();

            // call command's ExcuteReader
            SqlDataReader reader = cmd.ExecuteReader();
            var result = new List<byte[]>();
            try
            {
                while (reader.Read())
                {
                    var picture = (byte[])reader.GetValue(0);
                    result.Add(picture); 
                }
            }
            finally
            {
                // close reader and connection
                reader.Close();
                conn.Close();
            }
            model.Pictures = result;
        }
    }
}
