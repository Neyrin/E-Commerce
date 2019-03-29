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
                var cart = connection.Query<Cart>("SELECT * FROM Cart").ToList();

                return cart;
            }
        }

        public List<Cart> Get(int cartId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cartItem = connection.Query<Cart>("SELECT * FROM Cart WHERE CartId = @cartId", new { cartId }).ToList();

                return cartItem;
            }
        }

        public void Add(Cart cart)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var CartItem = connection.Execute("INSERT INTO Cart (CartId, ProductId) VALUES(@cartId, @productId)", cart);
            }
        }

    }

}




