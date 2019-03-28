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

        [HttpGet]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var CustomerItems = CartService.Get();
            if (CustomerItems != null)
            {
                return Ok(CustomerItems);
            }
            return BadRequest();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var CustomerItem = CartService.Get(id);
            if (CustomerItem != null)
            {
                return this.Ok(CustomerItem);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Cart cart)
        {
            var result = this.CartService.Add(cart);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}
