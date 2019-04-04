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
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public float TotalPrice { get; set; }
        public string OrderDate { get; set; }
        public List<Orders> OrderItems { get; set; }
    }
}
