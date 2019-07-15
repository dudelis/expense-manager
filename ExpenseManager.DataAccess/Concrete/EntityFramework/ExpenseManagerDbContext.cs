﻿using ExpenseManager.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class ExpenseManagerDbContext: DbContext
    {
        public ExpenseManagerDbContext(DbContextOptions<ExpenseManagerDbContext> options): base(options)
        {
            Database.Migrate();
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
                entity.Property(p => p.CreatedOn).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.UpdatedOn).IsRequired();
                entity.Property(p => p.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

                entity
                    .HasOne(p => p.Currency)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(p => p.CurrencyCode)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(p => p.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(p => p.AccountTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();

                entity.Property(p => p.CreatedOn).IsRequired();
                entity.Property(p => p.CreatedOn).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.UpdatedOn).IsRequired();
                entity.Property(p => p.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

                entity.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(p => p.Code);
                entity.Property(p => p.Code).HasMaxLength(3).IsFixedLength();
                entity.Property(p => p.Name).HasMaxLength(25);
            });
            modelBuilder.Entity<Expense>(entity => {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.CreatedOn).IsRequired();
                entity.Property(p => p.CreatedOn).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.UpdatedOn).IsRequired();
                entity.Property(p => p.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(p => p.Category).WithMany(p => p.Expenses).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.PayFromAccount).WithMany(p => p.Expenses).HasForeignKey(p => p.PayFromAccountId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Payee).WithMany(p => p.Expenses).HasForeignKey(p => p.PayeeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Currency).WithMany(p => p.Expenses).HasForeignKey(p => p.CurrencyCode).OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<ExpenseCategory>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.CreatedOn).IsRequired();
                entity.Property(p => p.CreatedOn).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.UpdatedOn).IsRequired();
                entity.Property(p => p.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

                entity
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Payee>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.CreatedOn).IsRequired();
                entity.Property(p => p.CreatedOn).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.UpdatedOn).IsRequired();
                entity.Property(p => p.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

                entity.Property(p => p.Name).IsRequired();

            });

        }
        public override int SaveChanges()
        {
            AddTimeStamps();
            return base.SaveChanges();
        }

        private void AddTimeStamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property("CreatedOn").CurrentValue = DateTime.UtcNow;
                }
                entity.Property("UpdatedOn").CurrentValue= DateTime.UtcNow;
            }
        }
    }
}
