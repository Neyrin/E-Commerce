using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Repositories;
using WebShop.Models;
using WebShop.Controllers;
using WebShop.Services;
using Dapper;
using System.Data.SqlClient;

namespace WebShop.Repositories
{
    public class ProductsRepository
    {
        private readonly string connectionString;

        public ProductsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Products> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var ProductsItem = connection.Query<Products>("SELECT * FROM Products").ToList();
                return ProductsItem;
            }
        }

        public Products Get(int productId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var Item = connection.QuerySingleOrDefault<Products>("SELECT * FROM Products WHERE productId = @productId", new { productId });
                return Item;
            }
        }

        public void Add(Products products)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var newsItem = connection.Execute("INSERT INTO Products (Image, ProductName, Description, Price) VALUES(@image, @productName, @description, @price)", products);
            }
        }
    }

}
