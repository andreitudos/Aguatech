using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aguatech.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aguatech.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
