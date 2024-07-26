/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountsApi.Models
{
    public class Discount
    {
        
    }
} */

namespace DiscountsApi.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Percentage { get; set; }
    }
}
