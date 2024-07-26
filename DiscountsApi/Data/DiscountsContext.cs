/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountsApi.Data
{
    public class DiscountsContext
    {
        
    }
} */
using Microsoft.EntityFrameworkCore;
using DiscountsApi.Models;

namespace DiscountsApi.Data
{
    public class DiscountsContext : DbContext
    {
        public DiscountsContext(DbContextOptions<DiscountsContext> options) : base(options) { }

        public DbSet<Discount> Discounts { get; set; }
    }
}
