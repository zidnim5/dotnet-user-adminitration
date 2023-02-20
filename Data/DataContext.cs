using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnet_user_adminitration.Data
{
     public class DataContext : DbContext
     {
          public DataContext(DbContextOptions<DataContext> options) : base(options)
          {

          }
          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               modelBuilder.Entity<User>(entity =>
              {
                   entity.HasKey(e => e.Uid);
                   entity.Property(e => e.Uid)
                    .ValueGeneratedNever();
                   entity.Property(e => e.Uid)
                    .IsRequired();
              });

               modelBuilder.Entity<UserDetail>(entity =>
              {
                   entity.HasKey(e => e.Uid);
                   entity.Property(e => e.Uid)
                    .ValueGeneratedNever();
                   entity.Property(e => e.Uid)
                    .IsRequired();
              });

               modelBuilder.Entity<Media>(entity =>
               {
                    entity.HasKey(e => e.Uid);
                    entity.Property(e => e.Uid)
                     .ValueGeneratedNever();
                    entity.Property(e => e.Uid)
                     .IsRequired();
               });

          }

          public DbSet<User> User { get; set; }
          public DbSet<UserDetail> UserDetail { get; set; }
          public DbSet<Media> Media { get; set; }
     }
}