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
    public class ProductsController : Controller
    {
        private readonly ProductsService ProductsService;

        public ProductsController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.ProductsService = new ProductsService(new ProductsRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var ProductsItem = ProductsService.Get();
            if (ProductsItem != null)
            {
                return Ok(ProductsItem);
            }
            return BadRequest();
        }


        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult Get(int id)
        //{
        //    var CustomerItem = ProductsService.Get(id);
        //    if (CustomerItem != null)
        //    {
        //        return this.Ok(CustomerItem);
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Post([FromBody]Products products)
        //{
        //    var result = this.ProductsService.Add(products);

        //    if (!result)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok();
        //}


    }
}
