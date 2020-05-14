using System;
using System.ComponentModel.DataAnnotations;

namespace apiLibrary
{

    public class Book
    {

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Id { get; private set; }

        public Book()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Book(string title, string description)
        {
            Title = title;
            Description = description;
            Id = Guid.NewGuid().ToString();
        }
    }

}