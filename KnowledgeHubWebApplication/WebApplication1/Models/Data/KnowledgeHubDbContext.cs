using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.Data
{
    public class KnowledgeHubDbContext : DbContext
    {
        public KnowledgeHubDbContext() : base("name = DefaultConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }


    }
}