using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EHealthcare.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
        }

        public string Name { get; set; }

        public string Author { get; set; }

        public double Price { get; set; }

        public string Detail { get; set; }

        public string ImageUrl { get; set; }
    }
}
