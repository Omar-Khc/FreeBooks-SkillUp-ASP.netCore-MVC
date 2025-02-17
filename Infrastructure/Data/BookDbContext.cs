using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Infrastructuree.ViewModels;

namespace Infrastructuree.Data
{
    public class BookDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //modelBuilder.Entity<Category>().has

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Users","Identity");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "Identity");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Identity");
            //modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Identity");
            //modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Identity");

            modelBuilder.Entity<Category>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            modelBuilder.Entity<LogGategory>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            modelBuilder.Entity<SubCategory>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            modelBuilder.Entity<LogSubCategory>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            modelBuilder.Entity<Book>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            modelBuilder.Entity<LogBook>().Property(x => x.Id).HasDefaultValueSql("(newid())");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<LogGategory> LogGategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<LogSubCategory> LogSubCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<LogBook> LogBooks { get; set; }
    }
}
