using System;
using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<ProductEntity> Product { get; set; }

        public MyContext (DbContextOptions<MyContext> options) : base (options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ProductEntity>(new ProductMap().Configure);
        }
    }
}