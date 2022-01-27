using Microsoft.EntityFrameworkCore;
using Spg.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Infrastructure
{
    public class WebDbContext : DbContext
    {
        public WebDbContext() { }
        public WebDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category>
    }
}
