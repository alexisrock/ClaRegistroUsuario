using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class PruebaContext : DbContext
    {

        public PruebaContext(DbContextOptions<PruebaContext> options) : base(options) { }
        public virtual DbSet<Users>? Users { get; set; }
        public virtual DbSet<Domain.Entities.Configuration>? Configurations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigurationConfiguration());
        }
    }
}
