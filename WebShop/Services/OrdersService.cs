using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using WebShop.Models;
using WebShop.Repositories;
using WebShop.Services;

namespace WebShop.Services
{
    public class OrdersService
    {
        private readonly OrdersRepository ordersRepository;

        public OrdersService(OrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public List<Orders> Get()
        {
            return this.ordersRepository.Get();
        }

        public Orders Get(int id)
        {
            return this.ordersRepository.Get(id)?.SingleOrDefault();
        }

        public bool Add(Orders orders)
        {
            if (orders != null)
            {
                ordersRepository.Add(orders);
                return true;
            }
            return false;
        }
    }
}
