using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ExpenseManager.DataAccess.Migrations
{
    public partial class Migration04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorUserId = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedUserId = table.Column<string>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    SourceAccountId = table.Column<int>(nullable: false),
                    DestinationAccountId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TransferDate = table.Column<DateTime>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransfers_Accounts_DestinationAccountId",
                        column: x => x.DestinationAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountTransfers_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransfers_Accounts_SourceAccountId",
                        column: x => x.SourceAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfers_DestinationAccountId",
                table: "AccountTransfers",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfers_ProfileId",
                table: "AccountTransfers",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfers_SourceAccountId",
                table: "AccountTransfers",
                column: "SourceAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTransfers");
        }
    }
}
