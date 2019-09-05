using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class WifiInfoContext : DbContext
    {
        public static String Table;
        public DbSet<WifiInfo>WifiInfos { get; set; }
       
        public WifiInfoContext(DbContextOptions<WifiInfoContext> options)
            : base(options)
        {
          //  Database.EnsureCreated();            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WifiInfo>().ToTable(Table);
        }
    }
}
