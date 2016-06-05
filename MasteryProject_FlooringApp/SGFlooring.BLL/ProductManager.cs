using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Factories;
using SGFlooring.Data.Interfaces;
using SGFlooring.Data.ProductRepo;
using SGFlooring.Models;

namespace SGFlooring.BLL
{
    public class ProductManager
    {
        private IProductRepository _repo;

        public ProductManager()
        {
            _repo = ProductRepositoryFactory.GetProductRepository();
        }

        private LogManager logManager = new LogManager();
        public List<Product> GetAllProducts()
        {
            return _repo.GetProductInfo();
        }

        public Response<Product> GetProduct(List<Product> products, string type)
        {
            var result = new Response<Product>();
            result.Data = new Product();
            try
            {
                var product = _repo.GetProduct(type);

                if (product == null)
                {
                    result.Message = "The Product You Want Does Not Exist In Our System.";
                    result.Success = false;
                    logManager.ErrorLogs(DateTime.Now, result.Message);
                }
                else
                {
                    result.Success = true;
                    result.Data = product;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "There was an error. Please try again later.";
                logManager.ErrorLogs(DateTime.Now, result.Message);

            }
            return result;

        }
    }
}
