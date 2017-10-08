using CloudSecurity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudSecurity.Infrastructure.Data
{
    class CloudSecurityContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ConfigurationOfUserSignature> ConfigurationOfUserSignatures { get; set; }
        public DbSet<UserSignature> UserSignatures { get; set; }

        //TODO сделать подключение из файла вынести из кода вне c#
        //https://metanit.com/sharp/entityframeworkcore/2.2.php 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=CloudSecurityDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //использование Fluent API
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);
            

        }
    }
}
