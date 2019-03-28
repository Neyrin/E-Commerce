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
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public List<Cart> Get()
        {
            return this.cartRepository.Get();
        }

        public Cart Get(int id)
        {
            return this.cartRepository.Get(id);
        }

        public bool Add(Cart cart)
        {
            if (cart != null)
            {
                cartRepository.Add(cart);
                return true;
            }
            return false;
        }
    }
}
