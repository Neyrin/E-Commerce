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

namespace WebShop.Models
{
    public class Products
    {
        public int ProductId { get; }
        public string Image { get; }
        public string ProductType { get; }
        public string ProductName { get; }
        public string Description { get; }
        public float Price { get; }

    }
}
