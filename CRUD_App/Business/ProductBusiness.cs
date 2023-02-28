using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_App.Data;
using CRUD_App.Common;

namespace CRUD_App.Business
{
    public static class ProductBusiness
    {
        private static ProductData data = new ProductData();
        public static List<Product> ListAll()
        {
            return data.ListAll();
        }
        public static Product Get(int id)
        {
            return data.Get(id);
        }
        public static void Add(Product product)
        {
            data.Add(product);
        }
        public static void Update(Product product)
        {
            data.Update(product);
        }
        public static void Delete(int id)
        {
            data.Delete(id);
        }
    }
}
