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
    public class OrderInfoRepository
    {
        private readonly string connectionString;

        public OrderInfoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<OrderInfo> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var OrderInfoItem = connection.Query<OrderInfo>("SELECT * FROM OrderInfo").ToList();
                return OrderInfoItem;
            }
        }

        public OrderInfo Get(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var OrderInfoItem = connection.QuerySingleOrDefault<OrderInfo>("SELECT * FROM OrderInfo WHERE OrderId = @id", new { id });
                return OrderInfoItem;
            }
        }

        public int Add(OrderInfo orderInfo)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                return connection.QuerySingle<int>(@"INSERT INTO OrderInfo (Name, Email, Adress, City, ZipCode, TotalPrice, OrderDate) 
                                                        VALUES(@name, @email, @adress, @city, @zipcode, @totalPrice, @orderDate)
                                                        SELECT @@IDENTITY", orderInfo);
            }
        }

    }

}
