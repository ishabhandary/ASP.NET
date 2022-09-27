using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]

        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name ="Article URL")]
        public string ArticleUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string SubmittedBy { get; set; }

        public bool IsApproved { get; set; }

        public DateTime DateSubmitted  { get; set; }
    }
}