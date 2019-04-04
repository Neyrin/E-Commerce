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
    public class OrderInfoController : Controller
    {
        private readonly OrderInfoService OrderInfoService;

        public OrderInfoController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.OrderInfoService = new OrderInfoService(new OrderInfoRepository(connectionString), new OrdersRepository(connectionString), new CartRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrderInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var CustomerItems = OrderInfoService.Get();
            if (CustomerItems != null)
            {
                return Ok(CustomerItems);
            }
            return BadRequest();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var CustomerItem = OrderInfoService.Get(id);
            if (CustomerItem != null)
            {
                return this.Ok(CustomerItem);
            }
            return NotFound();
        }

        [HttpPost("{cartId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]OrderInfo orderInfo, int cartId)
        {
            var result = this.OrderInfoService.Add(orderInfo, cartId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}
