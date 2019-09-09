using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class LppDatabaseContext :DbContext
    {
        //public LppDatabaseContext(DbContextOptions<LppDatabaseContext> options)
        //    :base (options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer($@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = {nameof(LppDatabaseContext)}; Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }
       public DbSet<Log> Logs { get; set; }
       public DbSet<LocationRoom> LocationRooms { get; set; }
    }
}
