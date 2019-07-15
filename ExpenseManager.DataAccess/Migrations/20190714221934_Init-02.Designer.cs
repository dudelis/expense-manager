﻿// <auto-generated />
using System;
using ExpenseManager.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpenseManager.DataAccess.Migrations
{
    [DbContext(typeof(ExpenseManagerDbContext))]
    [Migration("20190714221934_Init-02")]
    partial class Init02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpenseManager.Entities.Concrete.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountTypeId");

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("BalanceDate");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("CurrencyCode");

                    b.Property<string>("IconCode");

                    b.Property<bool>("IncludeInTotals");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("CurrencyCode");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ExpenseManager.Entities.Concrete.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("ExpenseManager.Entities.Concrete.Currency", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .IsFixedLength(true)
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .HasMaxLength(25);

                    b.HasKey("Code");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("ExpenseManager.Entities.Concrete.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("CurrencyCode");

                    b.Property<DateTime>("ExpenseDate");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int?>("PayFromAccountId");

                    b.Property<int?>("PayeeId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CurrencyCode");

                    b.HasIndex("PayFromAccountId");

                    b.HasIndex("PayeeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ExpenseManager.Entities.Concrete.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentCategoryId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("ExpenseCategories");
                });

            modelBuilder.Entity("ExpenseManager.Entities.Concrete.Payee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<string>("WebSite");

                    b.HasKey("Id");

                    b.ToTable("Payees");
                });

            modelBuilder.Entity("ExpenseManager.Entities.Concrete.Account", b =>
                {
                    b.HasOne("ExpenseManager.Entities.Concrete.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ExpenseManager.Entities.Concrete.Currency", "Currency")
                        .WithMany("Accounts")
                        .HasForeignKey("CurrencyCode")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ExpenseManager.Entities.Concrete.Expense", b =>
                {
                    b.HasOne("ExpenseManager.Entities.Concrete.ExpenseCategory", "Category")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ExpenseManager.Entities.Concrete.Currency", "Currency")
                        .WithMany("Expenses")
                        .HasForeignKey("CurrencyCode")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ExpenseManager.Entities.Concrete.Account", "PayFromAccount")
                        .WithMany("Expenses")
                        .HasForeignKey("PayFromAccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ExpenseManager.Entities.Concrete.Payee", "Payee")
                        .WithMany("Expenses")
                        .HasForeignKey("PayeeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ExpenseManager.Entities.Concrete.ExpenseCategory", b =>
                {
                    b.HasOne("ExpenseManager.Entities.Concrete.ExpenseCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
