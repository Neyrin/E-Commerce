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
        
        public int Add(Cart cart)
        {
            if (cart.ProductId == 0)
            {
                return 0;
            }
            else if (cart.CartId == 0)
            {
                cart.CartId = this.GetRandomCartId();
                this.cartRepository.Add(cart);
                return cart.CartId;
            }
            else
            {
                this.cartRepository.Add(cart);
                return 0;
            }
        }

        public int GetRandomCartId()

        {
            // Generate a random string with a given size
            var returnString = "";
            Random generateNumber = new Random();
            for (int i = 0; i < 6; i++)
            {
                int tmpNumber = generateNumber.Next(1, 9);
                returnString += tmpNumber.ToString();
            }
            int randNumber = Convert.ToInt32(returnString);
            return randNumber;

        }
    }
}
