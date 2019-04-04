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
    public class OrdersController : Controller
    {
        private readonly OrdersService OrdersService;

        public OrdersController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.OrdersService = new OrdersService(new OrdersRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Orders), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var OrdersItems = OrdersService.Get();
            if (OrdersItems != null)
            {
                return Ok(OrdersItems);
            }
            return BadRequest();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Orders), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var OrdersItem = OrdersService.Get(id);
            if (OrdersItem != null)
            {
                return this.Ok(OrdersItem);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Orders orders)
        {
            var result = this.OrdersService.Add(orders);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}
