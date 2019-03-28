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

        public Orders Get(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var OrdersItem = connection.QuerySingleOrDefault<Orders>("SELECT * FROM Orders WHERE Id = @id", new { id });
                return OrdersItem;
            }
        }

        public void Add(Orders orders)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var OrdersItem = connection.Execute("INSERT INTO Orders (Header, Body) VALUES(@header, @body)", orders);
            }
        }

    }

}
