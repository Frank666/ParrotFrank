using Microsoft.EntityFrameworkCore;
using ParrotFrankEntities.parrot_frank;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParrotFrankData
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Subcategories> Subcategories { get; set; }
    }
}
