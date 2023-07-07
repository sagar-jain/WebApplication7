using Microsoft.EntityFrameworkCore;
using System;
using WebApplication7.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }



    // public DbSet<Product> Products { get; set; }
    // Add other DbSet properties for other entities

    // Override OnModelCreating method if you need to configure entity relationships or other configurations
}