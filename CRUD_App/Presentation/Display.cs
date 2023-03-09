﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_App.Common;
using CRUD_App.Business;

namespace CRUD_App.Presentation
{
    public class Display
    {
        ProductBusiness productBusiness = new ProductBusiness();
        private void Show()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Menu" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries ");
            Console.WriteLine("2. Add entry ");
            Console.WriteLine("3. Update entry ");
            Console.WriteLine("4. Fetch entry by id ");
            Console.WriteLine("5. Delete entry by id ");
            Console.WriteLine("6. Exit ");
        }

        public void Input()
        {
            var operation = -1;
            do
            {
                Show();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAll(); break;
                    case 2: Add(); break;
                    case 3: Update(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                }
            } 
            while (operation != 6);
        }
        public Display()
        {
            Input();
        }

        private void Add()
        {
            Product product = new Product();
            Console.WriteLine("Enter name: ");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter stock: ");
            product.Stock = int.Parse(Console.ReadLine());
            productBusiness.Add(product);
        }

        private void ListAll()
        {
            List<Product> products = productBusiness.ListAll();
            foreach (var item in products)
            {
                Console.WriteLine("{0}  {1} {2}  {3} ", item.Id, item.Name, item.Price, item.Stock);
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter id to update ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine("Enter new name: ");
                product.Name = Console.ReadLine();
                Console.WriteLine("Enter new price: ");
                product.Price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter new stock: ");
                product.Stock = int.Parse(Console.ReadLine());
                productBusiness.Update(product);
            }
            else Console.WriteLine("Product not found!");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter id to fetch ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine("Id: " + product.Id);
                Console.WriteLine("Name: "+ product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Stock: " + product.Stock);
            }
            else Console.WriteLine("Product not found!");
        }

        private void Delete()
        {
            Console.WriteLine("Enter id to delete ");
            int id = int.Parse(Console.ReadLine());
            productBusiness.Delete(id);
            Console.WriteLine("Done!");
        }
    }
}
