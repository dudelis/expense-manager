using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ExpenseManager.DataAccess.Migrations
{
    public partial class Migration05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorUserId = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedUserId = table.Column<string>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Name = table.Column<string>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeCategories_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorUserId = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedUserId = table.Column<string>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    IncomeDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_IncomeCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "IncomeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeCategories_ProfileId",
                table: "IncomeCategories",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_AccountId",
                table: "Incomes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_CategoryId",
                table: "Incomes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ProfileId",
                table: "Incomes",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "IncomeCategories");
        }
    }
}
