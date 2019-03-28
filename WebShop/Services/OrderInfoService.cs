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
    public class OrderInfoService
    {
        private readonly OrderInfoRepository orderInfoRepository;

        public OrderInfoService(OrderInfoRepository orderInfoRepository)
        {
            this.orderInfoRepository = orderInfoRepository;
        }

        public List<OrderInfo> Get()
        {
            return this.orderInfoRepository.Get();
        }

        public OrderInfo Get(int id)
        {
            return this.orderInfoRepository.Get(id);
        }

        public bool Add(OrderInfo orderInfo)
        {
            if (orderInfo != null)
            {
                orderInfoRepository.Add(orderInfo);
                return true;
            }
            return false;
        }
    }
}
