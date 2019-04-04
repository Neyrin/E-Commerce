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
        public int ProductId { get; set; }
        public string Image { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set;  }
        public float Price { get; set; }

    }
}
