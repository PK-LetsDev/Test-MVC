﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.DataAccess.Data;

public class ApplicationDBContext : IdentityDbContext
{

	public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
	{

	}
	public DbSet<Category> Categories { get; set; }
	public DbSet<CoverType> CoverTypes { get; set; }
	public DbSet<Product> Product { get; set; }
	public DbSet<ApplicationUser> ApplicationUsers { get; set; }
	public DbSet<Company> Companies { get; set; }
	public DbSet<ShoppingCart> ShoppingCarts { get; set; }
	public DbSet<OrderHeader> OrderHeaders { get; set; }
	public DbSet<OrderDetail> OrderDetails { get; set; }
}