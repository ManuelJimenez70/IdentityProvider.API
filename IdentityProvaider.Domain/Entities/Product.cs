﻿using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IdentityProvaider.Domain.Entities
{
    public class Product
    {
        public int id_product { get; init; }
        public ProductName title { get; set; }
        public Price price { get; set; }
        public Description description { get; set; }
        public ImageProduct image { get; set; }
        public Rating rating { get; set; }

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

        public void setImage(ImageProduct image)
        {
            this.image = image;
        }

        public void setRating(Rating rating)
        {
            this.rating = rating;
        }
        public void setPrice(Price price)
        {
            this.price = price;
        }

    }
}
