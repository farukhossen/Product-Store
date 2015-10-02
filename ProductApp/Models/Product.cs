using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public String productName { get; set; }
        public int Price { get; set; }
        public String Description { get; set; }
    }
}