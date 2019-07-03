using ExpenseManager.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class ExpenseManagerDbContext: DbContext
    {
        public ExpenseManagerDbContext(DbContextOptions<ExpenseManagerDbContext> options): base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Payee> Payees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();

                entity.Property(p => p.CreatedOn).IsRequired();
                entity.Property(p => p.CreatedOn).ValueGeneratedOnAdd();
                entity.Property(p => p.CreatedOn).HasDefaultValueSql("GetDate()");

                entity.Property(p => p.UpdatedOn).IsRequired();
                entity.Property(p => p.UpdatedOn).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.UpdatedOn).HasDefaultValueSql("GetDate()");

            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(p => p.Code);
            });
            modelBuilder.Entity<ExpenseCategory>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();

                entity.Property(p => p.CreatedOn).IsRequired();
                entity.Property(p => p.CreatedOn).ValueGeneratedOnAdd();
                entity.Property(p => p.CreatedOn).HasDefaultValueSql("GetDate()");

                entity.Property(p => p.UpdatedOn).IsRequired();
                entity.Property(p => p.UpdatedOn).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.UpdatedOn).HasDefaultValueSql("GetDate()");

                entity
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            });





        }
    }
}
