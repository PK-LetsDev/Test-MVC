using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace WebApplication.DataAccess
{
    public class ApplicationDBContext : IdentityDbContext
    {
       
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
