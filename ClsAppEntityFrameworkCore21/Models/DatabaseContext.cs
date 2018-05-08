using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClsAppEntityFrameworkCore21.Models
{
    public sealed class DatabaseContext: DbContext
    {
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<People> People { get; set; }

        
        [DbFunction(FunctionName = "date")]
        public static DateTime Date(DateTime? value)
        {
            throw new NotImplementedException();
        }
        [DbFunction(FunctionName = "date")]
        public static DateTime Date(DateTime value)
        {
            throw new NotImplementedException();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>(x =>
            {
                x.ToTable("people");

                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                x.Property(p => p.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .HasMaxLength(50);

                x.Property(p => p.Created)
                    .HasColumnName("created");                                    
            });

            modelBuilder.Entity<People>()
                .HasData(
                new People
                {
                    Id = 1,
                    Name = "Example 1",
                    Created = DateTime.Now.AddDays(-1)
                }, 
                new People
                {
                    Id = 2,
                    Name = "Example 2",
                    Created = DateTime.Now.AddDays(-2)
                });

            modelBuilder.HasDbFunction(() => Date(default(DateTime)));
                
        }
    }
}
