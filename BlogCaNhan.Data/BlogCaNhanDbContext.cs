using BlogCaNhan.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCaNhan.Data
{
    public class BlogCaNhanDbContext : DbContext
    {
        public BlogCaNhanDbContext() { }

        public BlogCaNhanDbContext(DbContextOptions<BlogCaNhanDbContext> options)
            : base(options){}

        public DbSet<Admin> Admin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();
            optionsBuilder.UseSqlServer(builder.GetConnectionString("BlogCaNhan"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
