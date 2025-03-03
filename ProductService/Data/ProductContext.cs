﻿// Data/ProductContext.cs
using Microsoft.EntityFrameworkCore;
using ProductService.Models;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}

