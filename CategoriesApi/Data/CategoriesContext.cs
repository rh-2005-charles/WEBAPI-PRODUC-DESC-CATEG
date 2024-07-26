/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoriesApi.Data
{
    public class CategoriesContext
    {
        
    }
} */

using Microsoft.EntityFrameworkCore;
using CategoriesApi.Models;

namespace CategoriesApi.Data
{
    public class CategoriesContext : DbContext
    {
        public CategoriesContext(DbContextOptions<CategoriesContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}

