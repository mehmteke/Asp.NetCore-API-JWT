﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApiWithTokenDBContext context) : base(context) { }
         
        public async Task AddProductAsync(Product product)
        {
            await context.Product.AddAsync(product);
        }

        public async Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId)
        {
            IEnumerable<Product> products;
            products = await context.Product.ToListAsync();
            products = (from a in products.Where(product => product.CategoryId == categoryId) select a).ToList();

          return products;
        }

        public async Task<Product> FindByIdAsync(int productId)
        {
            return await context.Product.FindAsync(productId);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Product.ToListAsync(); 
        }
        public async Task RemoveProductAsync(int productId)
        {
            // Product product = await context.Product.FindAsync(productId);
            Product product = await FindByIdAsync(productId);
            context.Product.Remove(product);
        }
        public void  UpdateProduct(Product product)
        {
            context.Product.Update(product);
        }
    }
}
