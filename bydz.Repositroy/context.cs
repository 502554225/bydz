using bydz.Models;
using bydz.Repositroy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace bydz.Repositroy
{
    public class context : DbContext
    {
        public context(DbContextOptions<context> options)
            : base(options)
        {
        }

        public DbSet<Poker> Pokers { get; set; }
        public DbSet<myPoker> myPokers { get; set; }
        public DbSet<array> array { get; set; }
        public DbSet<baseInfor> baseInfors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<array>()
                .HasKey(c => new { c.UserId, c.PokerId });
            modelBuilder.Entity<myPoker>()
               .HasKey(c => new { c.UserId, c.PokerId });
        }

    }
}
