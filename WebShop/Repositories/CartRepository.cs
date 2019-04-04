using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
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
                var cartItem = connection.Query<Cart>("SELECT * FROM Cart").ToList();

                return cartItem;
            }
        }

        public List<Cart> Get(int cartId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cart = connection.Query<Cart>("SELECT cart.cartid, cart.productId, productName, price FROM Cart INNER JOIN products ON cart.productId=products.productId WHERE cart.cartId=@cartId", new { cartId }).ToList();

                return cart;
            }
        }

        public void Add(Cart cart)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Cart (CartId, ProductId) VALUES(@cartId, @productId)", cart);
            }
        }

        public void Delete(int cartId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM Cart Where CartId = @cartId", new { cartId });
            }
        }

    }

}




