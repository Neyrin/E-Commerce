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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace WebShop.Controllers
{
    [Route("api/[Controller]")]
    public class CustomerController : Controller
    {
        private readonly CartService cartService;

        public CustomerController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(new CartRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Cart>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var cart = this.cartService.Get();
            if (cart == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cart);
            }
        }

        [HttpGet("{cartId}")]
        [ProducesResponseType(typeof(List<Cart>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int cartId)
        {
            var id = this.cartService.Get(cartId);

            return Ok(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Cart cart)
        {
            var newCart = this.cartService.Add(cart);

            if (newCart == 0)
            {
                return BadRequest();
            }
            else if (newCart == 1)
            {
            return Ok();
            }
            else
            {
                return Ok(newCart);
            }

        }


    }
}
