using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = IdentityProvaider.Domain.ValueObjects.Image;

namespace IdentityProvaider.Domain.Entities
{
    public class Product
    {
        public int id_product { get; init; }
        public ProductName title { get; private set; }
        public Price price { get; private set; }
        public Description description { get; private set; }
        public Category category { get; private set; }
        public ValueObjects.Image image { get; private set; }
        public Rating rating { get; private set; }

        public Product()
        {

        }

        public Product(int id_user)
        {
            this.id_product = id_user;
        }

        public void setTitle(ProductName title)
        {
            this.title = title;
        }

        public void setDescription(Description description)
        {
            this.description = description;
        }
        public void setCategory(Category category)
        {
            this.category = category;
        }

        public void setImage(Image image)
        {
            this.image = image;
        }

        public void setRating(Rating rating)
        {
            this.rating = rating;
        }
        public void setPrice(Price rating)
        {
            this.price = rating;
        }

    }
}
