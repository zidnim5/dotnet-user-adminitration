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
          public DbSet<User> User { get; set; }
          public DbSet<UserDetail> UserDetail { get; set; }
          public DbSet<Media> Media { get; set; }
     }
}