using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using WebShop.Repositories;

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

        public List<Cart> Get(int cartId)
        {
            if (cartId == 0)
            {
                return null;
            }
            return this.cartRepository.Get(cartId);
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
                return cart.CartId;
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
