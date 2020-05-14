using System;
using System.ComponentModel.DataAnnotations;

namespace apiLibrary
{
    public class Drink
    {

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Id { get; private set; }

         public Drink()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Drink(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
            Id = Guid.NewGuid().ToString();
        }

    }
}