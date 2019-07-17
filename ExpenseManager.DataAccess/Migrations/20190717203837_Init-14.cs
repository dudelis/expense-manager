﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseManager.DataAccess.Migrations
{
    public partial class Init14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AccountTypes_Name",
                table: "AccountTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AccountTypes",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AccountTypes",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AccountTypes_Name",
                table: "AccountTypes",
                column: "Name");
        }
    }
}
