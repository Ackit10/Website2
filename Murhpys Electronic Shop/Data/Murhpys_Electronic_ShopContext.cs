using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Murhpys_Electronic_Shop.Models;

namespace Murhpys_Electronic_Shop.Data
{
    public class Murhpys_Electronic_ShopContext : DbContext
    {
        public Murhpys_Electronic_ShopContext (DbContextOptions<Murhpys_Electronic_ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Murhpys_Electronic_Shop.Models.Items> Items { get; set; } = default!;


        
    }


}
