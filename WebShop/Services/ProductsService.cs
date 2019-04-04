using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using WebShop.Models;
using WebShop.Repositories;
using WebShop.Services;

namespace WebShop.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository productsRepository;

        public ProductsService(ProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public List<Products> Get()
        {
            return this.productsRepository.Get();
        }

        public Products Get(int productId)
        {
            return this.productsRepository.Get(productId);
        }

        public bool Add(Products products)
        {
            if (products != null)
            {
                productsRepository.Add(products);
                return true;
            }
            return false;
        }
    }
}
