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
    public class CartRepository
    {
        private readonly string connectionString;

        public CartRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cart> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var CartItem = connection.Query<Cart>("SELECT * FROM Cart").ToList();
                return CartItem;
            }
        }

        public Cart Get(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var CartItem = connection.QuerySingleOrDefault<Cart>("SELECT * FROM Cart WHERE Id = @id", new { id });
                return CartItem;
            }
        }

        public void Add(Cart cart)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var CartItem = connection.Execute("INSERT INTO Cart (Header, Body) VALUES(@header, @body)", cart);
            }
        }

    }

}




