using ShopManager.DBAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DBAccess
{
    public class DataAcces
    {
        public Product GetProductById(int id)
        {
            var dbAccess = new DBAcces();
            var procedure = "dbo.spGetProductById";
            var parameters = new { Id = id };

            return dbAccess.LoadDataFromDB<Product, dynamic>(procedure, parameters, "ShopManager").FirstOrDefault();
        }
    }
}
