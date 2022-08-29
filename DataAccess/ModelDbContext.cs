using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTestAPI.Entities;

namespace TechnicalTestAPI.GlobalModel
{
    public class ModelDbContext : DbContext
    {
        public ModelDbContext(DbContextOptions db): base(db) { }

        public DbSet<SELLER> SELLERs { get; set; }

        public DbSet<CITY> CITies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<CITY>()
                .Navigation(p => p.SELLERs).UsePropertyAccessMode(PropertyAccessMode.Property).AutoInclude();

            modelBuilder.Entity<SELLER>() 
            .HasOne(p => p.CITies)
            .WithMany(b=>b.SELLERs)
            .HasForeignKey(p => p.CITY_ID)
            .HasConstraintName("FK_SELLER_CITY");

            modelBuilder.Entity<SELLER>().Navigation(p => p.CITies).UsePropertyAccessMode(PropertyAccessMode.Property).AutoInclude();
        }
    }


}
