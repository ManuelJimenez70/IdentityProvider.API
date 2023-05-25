using IdentityProvaider.API.Commands;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace IdentityProvaider.API.AplicationServices
{
    public class ProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> CreateProduct()
        {
            Console.WriteLine("keeee");
            Random random = new Random();
            int randomIndex = random.Next(1, 31);
            var apiUrl = "https://fakestoreapi.com/products/" + randomIndex;
            using (var client = new HttpClient()) {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    var p = JsonSerializer.Deserialize<TempProduct>(content);
                    Console.WriteLine(p.title);
                    Product product = new Product
                    {
                        title = ProductName.create(p.title),
                        description = Description.create(p.description),
                        category = Category.create(p.category),
                        image = ImageProduct.create(p.image),
                        rating = Rating.create((int)random.Next(0, 11)),
                        price = Price.create((int)(p.price * 10))
                    };
                    Console.WriteLine(product.price);
                    if (product != null)
                    {
                        await repository.AddProduct(product);
                        return "Todo bien";
                    }
                    else {
                        return await CreateProduct();
                    }
                  
                }
                else {
                    return "Mal";
                }
            }
        }

        public async Task<List<Product>> GetProductsByNum(int numI, int numF)
           {
               return await repository.GetProductsByNum(numI, numF);
           }
       

        
    }

    public class TempProduct
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        //public Ratingg rating { get; set; }
    }

    public class Ratingg
    {
        public double rate { get; set; }
        public int count { get; set; }
    }
}