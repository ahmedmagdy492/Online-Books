using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_books.Models;

namespace Online_books.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {        
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RealLanguageCategory> LanguageCategories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>(ir => ir.HasData(new IdentityRole { Name = "User", NormalizedName = "USER" }));
            builder.Entity<IdentityRole>(ir => ir.HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }));
        }
    }
}
