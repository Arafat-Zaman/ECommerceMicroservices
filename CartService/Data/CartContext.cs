﻿using Microsoft.EntityFrameworkCore;
using CartService.Models;
using System.Collections.Generic;

namespace CartService.Data
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options) { }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
