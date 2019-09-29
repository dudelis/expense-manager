using ExpenseManager.Auth.Concrete;
using ExpenseManager.Auth.Interfaces;
using ExpenseManager.Entities.Concrete;
using ExpenseManager.Entities.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class ExpenseManagerDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IGetClaimsProvider _claimsProvider;

        public ExpenseManagerDbContext(DbContextOptions<ExpenseManagerDbContext> options, IGetClaimsProvider claimsProvider) : base(options)
        {
            _claimsProvider = claimsProvider;
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransfer> AccountTransfers { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileMember> ProfileMembers { get; set; }
        public DbSet<ProfileConfiguration> ProfileConfigurations { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Primary Key
            foreach (var entityOwnedBy in modelBuilder.Model.GetEntityTypes().Where(x => x.ClrType.GetInterface(nameof(IEntity)) != null))
            {
                var entity = modelBuilder.Entity(entityOwnedBy.ClrType);
                entity.HasKey(nameof(IEntity.Id));
                entity.Property(nameof(IEntity.Id)).ValueGeneratedOnAdd();
            }
            //ICreationAudited
            foreach (var entityOwnedBy in modelBuilder.Model.GetEntityTypes().Where(x => x.ClrType.GetInterface(nameof(ICreationAudited)) != null))
            {
                var entity = modelBuilder.Entity(entityOwnedBy.ClrType);
                //CreatedTime
                entity.Property(nameof(ICreationAudited.CreatedTime))
                    .IsRequired()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("GETUTCDATE()");

                //Created User
                entity.Property(nameof(ICreationAudited.CreatorUserId))
                    .IsRequired()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            }
            //IModificationAudited
            foreach (var entityOwnedBy in modelBuilder.Model.GetEntityTypes().Where(x => x.ClrType.GetInterface(nameof(IModificationAudited)) != null))
            {
                var entity = modelBuilder.Entity(entityOwnedBy.ClrType);
                //ModifiedTime
                entity.Property(nameof(IModificationAudited.ModifiedTime))
                    .IsRequired()
                    .HasDefaultValueSql("GETUTCDATE()");

                //Modified By
                entity.Property(nameof(IModificationAudited.LastModifiedUserId)).IsRequired();
            }
            //IProfileDependent
            foreach (var entityOwnedBy in modelBuilder.Model.GetEntityTypes().Where(x => x.ClrType.GetInterface(nameof(IProfileDependent)) != null))
            {
                var entity = modelBuilder.Entity(entityOwnedBy.ClrType);
                entity.Property(nameof(IProfileDependent.ProfileId))
                    .IsRequired()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                entity.HasIndex(nameof(IProfileDependent.ProfileId));
            }

            modelBuilder.Entity<Account>(entity =>
            {
                entity
                    .HasOne(p => p.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(p => p.AccountTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasMany(p => p.SourceAccountTransfers)
                    .WithOne(p => p.SourceAccount)
                    .HasForeignKey(p => p.SourceAccountId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasMany(p => p.DestinationAccountTransfers)
                    .WithOne(p => p.DestinationAccount)
                    .HasForeignKey(p => p.DestinationAccountId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<AccountTransfer>(entity =>
            {
                entity.Property(p => p.TransferDate).IsRequired();
                entity.Property(p => p.Amount).IsRequired();

            });
            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(p => p.Code)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();
                entity.Property(p => p.Name)
                    .HasMaxLength(25)
                    .IsRequired();

            });
            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasOne(p => p.Category).WithMany(p => p.Expenses).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.PayFromAccount).WithMany(p => p.Expenses).HasForeignKey(p => p.PayFromAccountId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Payee).WithMany(p => p.Expenses).HasForeignKey(p => p.PayeeId).OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<Income>(entity =>
            {
                entity
                    .HasOne(p => p.Category)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasOne(p => p.Account)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(p => p.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(p => p.IncomeDate).IsRequired();
                entity.Property(p => p.Amount).IsRequired();
            });
            modelBuilder.Entity<IncomeCategory>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();
            });
            modelBuilder.Entity<ExpenseCategory>(entity =>
            {
                entity
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Payee>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();
            });
            modelBuilder.Entity<Profile>(entity =>
            {
                entity
                    .HasOne(p => p.ProfileConfiguration)
                    .WithOne(p => p.Profile)
                    .HasForeignKey<ProfileConfiguration>(p => p.ProfileId);
            });

            modelBuilder.Entity<ProfileMember>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.UserId).IsRequired();
                entity.HasOne(p => p.Profile)
                    .WithMany(p => p.ProfileMembers)
                    .HasForeignKey(p => p.ProfileId)
                    .OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<UserSettings>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasAlternateKey(a => a.UserId);
                entity.Property(p => p.UserId).IsRequired();
                entity.HasOne(p => p.DefaultProfile)
                    .WithMany(p => p.UserSettings)
                    .HasForeignKey(p => p.DefaultProfileId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Account>().HasQueryFilter(x => x.ProfileId == _claimsProvider.UserProfileId);
            modelBuilder.Entity<AccountTransfer>().HasQueryFilter(x => x.ProfileId == _claimsProvider.UserProfileId);
            modelBuilder.Entity<AccountType>().HasQueryFilter(x => x.ProfileId == _claimsProvider.UserProfileId);
            modelBuilder.Entity<Currency>().HasQueryFilter(x => x.ProfileId == _claimsProvider.UserProfileId);
            modelBuilder.Entity<Expense>().HasQueryFilter(x => x.ProfileId == _claimsProvider.UserProfileId);
            modelBuilder.Entity<ExpenseCategory>().HasQueryFilter(x => x.ProfileId == _claimsProvider.UserProfileId);
            modelBuilder.Entity<Income>().HasQueryFilter(x => x.ProfileId == _claimsProvider.UserProfileId);
            modelBuilder.Entity<IncomeCategory>().HasQueryFilter(x => x.ProfileId == _claimsProvider.UserProfileId);
            modelBuilder.Entity<Payee>().HasQueryFilter(x => x.ProfileId == _claimsProvider.UserProfileId);
            modelBuilder.Entity<Profile>().HasQueryFilter(x => x.ProfileMembers.Any(p => p.UserId == _claimsProvider.UserId));
            modelBuilder.Entity<ProfileConfiguration>().HasQueryFilter(x => x.ProfileId == _claimsProvider.UserProfileId);
            modelBuilder.Entity<UserSettings>().HasQueryFilter(x => x.UserId == _claimsProvider.UserId);

        }
        public override int SaveChanges()
        {
            AddTimeStamps();
            SetProfileGuid();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken token)
        {
            AddTimeStamps();
            SetProfileGuid();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, token);
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
                    entity.Property("CreatorUserId").CurrentValue = _claimsProvider.UserId;
                if (entity.Entity is IModificationAudited)
                    entity.Property("LastModifiedUserId").CurrentValue = _claimsProvider.UserId;
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
                    entity.Property("LastModifiedUserId").CurrentValue = _claimsProvider.UserId;
                }
            }
        }
        private void SetProfileGuid()
        {
            var addedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added && x.Entity is IProfileDependent);
            foreach (var entry in addedEntries)
            {
                var entity = entry.Entity as IProfileDependent;
                entity.SetProfileId(_claimsProvider.UserProfileId);
            }
        }
    }
}
