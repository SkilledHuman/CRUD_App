using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_App.Data;
using CRUD_App.Common;

namespace CRUD_App.Business
{
    public class ProductBusiness
    {
        private ProductData data = new ProductData();
        public List<Product> ListAll()
        {
            return data.ListAll();
        }
        public Product Get(int id)
        {
            return data.Get(id);
        }
        public void Add(Product product)
        {
            data.Add(product);
        }
        public void Update(Product product)
        {
            data.Update(product);
        }
        public void Delete(int id)
        {
            data.Delete(id);
        }
    }
}
