using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IdentityProvaider.Infraestructure
{
    public class ProductRepository: IProductRepository
    {
        DatabaseContext db;

        public ProductRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task AddProduct(Product product)
        {
            await db.AddAsync(product);
            await db.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetProductsByNum(int numI, int numF)
        {
            List<Product> products = db.Products.Skip(numI).Take((numF - numI)).ToList();
            return products;
        }


    }
}
