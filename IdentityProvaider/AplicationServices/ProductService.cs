using IdentityProvaider.API.Commands;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using System;
using static System.Net.Mime.MediaTypeNames;
using Image = IdentityProvaider.Domain.ValueObjects.Image;

namespace IdentityProvaider.API.AplicationServices
{
    public class ProductService
    {
        private readonly IProductRepository repository;
        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        /*   public async Task CreateProduct()
           {
               Random random = new Random();
               int randomIndex = random.Next(1, 31);
               string apiUrl = "https://fakestoreapi.com/products/" + randomIndex + "";

               Product product = new Product();
               product.setTitle(ProductName.create("Mens Casual Slim Fit"));
               product.setDescription(Description.create("The color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description."));
               product.setCategory(Category.create("men's clothing"));
               product.setImage(Image.create("https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_.jpg"));
               product.setRating(Rating.create(Convert.ToInt32(Math.Round(15.99 * 10 * 2))));
               product.setPrice(Price.create(Convert.ToInt32(2.1 * 10)));
               await repository.AddProduct(product);
               using (HttpClient client = new HttpClient())
               {
                   HttpResponseMessage response = await client.GetAsync(apiUrl);

                   if (response.IsSuccessStatusCode)
                   {
                       string jsonResponse = await response.Content.ReadAsStringAsync();
                       Console.WriteLine(jsonResponse);

                       TempProduct p = JsonSerializer.Deserialize<TempProduct>(jsonResponse);

                       int id = p.id;
                       string title = p.title;
                       double price = p.price;
                       string description = p.description;
                       string category = p.category;
                       string image = p.image;
                       double ratingRate = p.rating.rate;
                       double ratingCount = p.rating.count;

                       product = new Product();
                       product.setTitle(ProductName.create(title));
                       product.setDescription(Description.create(description));
                       product.setCategory(Category.create(category));
                       product.setImage(Image.create(image));
                       product.setRating(Rating.create(Convert.ToInt32(Math.Round(ratingRate * 10 * 2))));
                       product.setPrice(Price.create(Convert.ToInt32(price * 10)));
                       await repository.AddProduct(product);

                       Console.WriteLine($"Id: {id}");
                       Console.WriteLine($"Title: {title}");
                       Console.WriteLine($"Price: {price}");
                       Console.WriteLine($"Description: {description}");
                       Console.WriteLine($"Category: {category}");
                       Console.WriteLine($"Image: {image}");
                       Console.WriteLine($"Rating Rate: {ratingRate}");

                       }
                   else
                   {
                   }
               }

           }*/

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
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public Ratingg rating { get; set; }
    }

    public class Ratingg
    {
        public double rate { get; set; }
        public int count { get; set; }
    }
}