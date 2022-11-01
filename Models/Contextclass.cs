using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using expanse_Tracker.Models;

namespace expanse_Tracker.Models
{
    public class ExpanseDbContext : IdentityDbContext<ApplicationUser>
    {
        public ExpanseDbContext(DbContextOptions<ExpanseDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ExpenseCategory>()
                .HasIndex(x => x.CategoryName).IsUnique();
            modelBuilder.Entity<Signup>().HasNoKey();
            modelBuilder.Entity<Login>().HasNoKey();
           
        }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Expanses> Expanses { get; set; }
        public DbSet<expanse_Tracker.Models.Signup> Signup { get; set; }
        public DbSet<expanse_Tracker.Models.Login> Login { get; set; }
    }
}
