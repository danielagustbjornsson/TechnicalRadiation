using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Contexts
{
    public class NewsDbContext : DbContext
    {

        public NewsDbContext(DbContextOptions<NewsDbContext> options)
            : base(options)
        {

        }


        public DbSet<Category> categories {  get; set; }
        public DbSet<Author> Authors {  get; set; }
        public DbSet<NewsItem> NewsItems {  get; set; }
    }
}
