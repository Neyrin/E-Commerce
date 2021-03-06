﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebShop.Models;
using WebShop.Repositories;
using WebShop.Services;

namespace WebShop.Controllers
{
    [Route("api/[Controller]")]
    public class CartController : Controller
    {
        private readonly CartService cartService;

        public CartController(IConfiguration configuration)
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
                return Ok(newCart);
        }


    }
}
