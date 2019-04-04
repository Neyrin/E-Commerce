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
        private readonly OrdersRepository ordersRepository;
        private readonly CartRepository cartRepository;

        public OrderInfoService(OrderInfoRepository orderInfoRepository, OrdersRepository ordersRepository, CartRepository cartRepository)
        {
            this.orderInfoRepository = orderInfoRepository;
            this.ordersRepository = ordersRepository;
            this.cartRepository = cartRepository;
        }

        public List<OrderInfo> Get()
        {
            return this.orderInfoRepository.Get();
        }

        public OrderInfo Get(int id)
        {
            var orderInfo = this.orderInfoRepository.Get(id);
            if(orderInfo == null)
            {
                return null;
            }

            orderInfo.OrderItems = this.ordersRepository.Get(id);
            return orderInfo;
        }

        public bool Add(OrderInfo orderInfo, int cartId)
        {
            if (orderInfo == null)
            {
                return false;
            }

            var carts = cartRepository.Get(cartId);

            if (carts == null || !carts.Any())
            {
                return false;
            }

            var totalPrice = carts.Sum(x => x.Price);
            orderInfo.TotalPrice = totalPrice;
            orderInfo.OrderDate = DateTime.Now.ToString();

            var orderId = orderInfoRepository.Add(orderInfo);

            foreach (var cart in carts)
            {
                var orderItem = new Orders
                {
                    OrderId = orderId,
                    ProductName = cart.ProductName,
                    ProductID = cart.ProductId,
                    Price = cart.Price
                };

                ordersRepository.Add(orderItem);
            }

            return true;
        }
    }
}
