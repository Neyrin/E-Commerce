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
        private readonly CartService CartService;

        public CustomerController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.CartService = new CartService(new CartRepository(connectionString));
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Cart cart)
        {
            var newCart = this.CartService.Add(cart);

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
