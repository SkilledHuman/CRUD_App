using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_App.Common;

namespace CRUD_App.Data
{
    public class ProductData
    {
        string connectionString = "Server = DESKTOP-85PFVUK; Database = Shop; integrated security = true;";
        public List<Product> ListAll()
        {
            List<Product> products = new List<Product>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using(con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Product;";
                SqlDataReader reader = cmd.ExecuteReader();
                using(reader)
                {
                    while (reader.Read())
                    {
                        Product product = new Product((int)reader.GetValue(0), (string)reader.GetValue(1),
                            (decimal)reader.GetValue(2), (int)reader.GetValue(3));
                        products.Add(product);
                    }
                }
            }
            con.Close();
            return products;
        }

        public Product Get(int id)
        {
            Product product = null;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Product where id = @id;";
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                using(reader)
                {
                    if(reader.Read())
                    {
                        product = new Product((int)reader.GetValue(0), (string)reader.GetValue(1),
                            (decimal)reader.GetValue(2), (int)reader.GetValue(3));
                    }
                }

            }
            con.Close();
            return product;
        }

        public void Add(Product product)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using(con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert into Product(name, price, stock) values (@name, @price, @stock);";
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public void Update(Product product)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update Product set name = @name, price = @price, stock = @stock where id = @id;";
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public void Delete(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Product where id = @id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}
