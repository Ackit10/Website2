using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Murhpys_Electronic_Shop.Models;

namespace Murhpys_Electronic_Shop.Data
{
    public class EmailsDatabaseContext : DbContext
    {
        public EmailsDatabaseContext (DbContextOptions<EmailsDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Murhpys_Electronic_Shop.Models.Emails> Emails { get; set; } = default!;
    }
}
