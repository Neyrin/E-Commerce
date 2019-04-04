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
    public class OrdersRepository
    {
        private readonly string connectionString;

        public OrdersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Orders> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var OrdersItem = connection.Query<Orders>("SELECT * FROM Orders").ToList();
                return OrdersItem;
            }
        }

        public List<Orders> Get(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var OrdersItem = connection.Query<Orders>("SELECT * FROM Orders WHERE OrderId = @id", new { id });
                return OrdersItem.ToList();
            }
        }

        public void Add(Orders orders)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var OrdersItem = connection.Execute(@"INSERT INTO Orders (OrderId, ProductName, ProductId, Price) 
                                                      VALUES(@orderId, @productName, @productId, @price)", orders);
            }
        }

    }

}
