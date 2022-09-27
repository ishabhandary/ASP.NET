using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Kindly enter category name!")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}