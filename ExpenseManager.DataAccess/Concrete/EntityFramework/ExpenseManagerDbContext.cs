using ExpenseManager.Entities.Concrete;
using ExpenseManager.Entities.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ExpenseManager.Auth.Concrete;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class ExpenseManagerDbContext: IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ExpenseManagerDbContext(DbContextOptions<ExpenseManagerDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Payee> Payees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.CreatedTime).IsRequired();
                entity.Property(p => p.CreatedTime).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedTime).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.ModifiedTime).IsRequired();
                entity.Property(p => p.ModifiedTime).HasDefaultValueSql("GETUTCDATE()");

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

                entity.Property(p => p.CreatedTime).IsRequired();
                entity.Property(p => p.CreatedTime).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedTime).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.ModifiedTime).IsRequired();
                entity.Property(p => p.ModifiedTime).HasDefaultValueSql("GETUTCDATE()");

                entity.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).HasMaxLength(3).IsFixedLength();
                entity.Property(p => p.Name).HasMaxLength(25); entity.Property(p => p.CreatedTime).IsRequired();

                entity.Property(p => p.CreatedTime).IsRequired();
                entity.Property(p => p.CreatedTime).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedTime).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.ModifiedTime).IsRequired();
                entity.Property(p => p.ModifiedTime).HasDefaultValueSql("GETUTCDATE()");
            });
            modelBuilder.Entity<Expense>(entity => {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.CreatedTime).IsRequired();
                entity.Property(p => p.CreatedTime).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedTime).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.ModifiedTime).IsRequired();
                entity.Property(p => p.ModifiedTime).HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(p => p.Category).WithMany(p => p.Expenses).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.PayFromAccount).WithMany(p => p.Expenses).HasForeignKey(p => p.PayFromAccountId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Payee).WithMany(p => p.Expenses).HasForeignKey(p => p.PayeeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Currency).WithMany(p => p.Expenses).HasForeignKey(p => p.CurrencyCode).OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<ExpenseCategory>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.CreatedTime).IsRequired();
                entity.Property(p => p.CreatedTime).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedTime).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.ModifiedTime).IsRequired();
                entity.Property(p => p.ModifiedTime).HasDefaultValueSql("GETUTCDATE()");

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
                entity.Property(p => p.CreatedTime).IsRequired();
                entity.Property(p => p.CreatedTime).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.CreatedTime).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(p => p.ModifiedTime).IsRequired();
                entity.Property(p => p.ModifiedTime).HasDefaultValueSql("GETUTCDATE()");

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
            //Added values
            var addedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var entity in addedEntities)
            {
                if (entity.Entity is IHasCreationTime)
                    entity.Property("CreatedTime").CurrentValue = DateTime.UtcNow;
                if (entity.Entity is IHasModificationTime)
                    entity.Property("ModifiedTime").CurrentValue = DateTime.UtcNow;
                if (entity.Entity is ICreationAudited)
                    entity.Property("CreatorUserId").CurrentValue = _httpContextAccessor.HttpContext.User.Identity.Name;
                if (entity.Entity is IModificationAudited)
                    entity.Property("LastModifiedUserId").CurrentValue = _httpContextAccessor.HttpContext.User.Identity.Name;                
            }
            var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var entity in modifiedEntities)
            {
                if (entity.Entity is IHasModificationTime)
                {
                    entity.Property("ModifiedTime").CurrentValue = DateTime.UtcNow;
                }
                    
                if (entity.Entity is IModificationAudited)
                {
                    entity.Property("LastModifiedUserId").CurrentValue = _httpContextAccessor.HttpContext.User.Identity.Name;
                }
                    
            }                        
        }

    }
}
