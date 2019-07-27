using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseManager.DataAccess.Migrations
{
    public partial class Migration16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Currencies_CurrencyCode",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Currencies_CurrencyCode",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Payees",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Payees",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Expenses",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Expenses",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "ExpenseCategories",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "ExpenseCategories",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "AccountTypes",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "AccountTypes",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Accounts",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Accounts",
                newName: "CreatedTime");

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Payees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "Payees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "ExpenseCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "ExpenseCategories",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Currencies",
                nullable: true,
                oldClrType: typeof(string),
                oldFixedLength: true,
                oldMaxLength: 3);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Currencies",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Currencies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Currencies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "Currencies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedTime",
                table: "Currencies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "AccountTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "AccountTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Currencies_CurrencyCode",
                table: "Accounts",
                column: "CurrencyCode",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Currencies_CurrencyCode",
                table: "Expenses",
                column: "CurrencyCode",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Currencies_CurrencyCode",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Currencies_CurrencyCode",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Payees");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Payees");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ExpenseCategories");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "ExpenseCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "AccountTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "AccountTypes");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "Payees",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Payees",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "Expenses",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Expenses",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "ExpenseCategories",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "ExpenseCategories",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "AccountTypes",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "AccountTypes",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "Accounts",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Accounts",
                newName: "CreatedOn");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Currencies",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Currencies_CurrencyCode",
                table: "Accounts",
                column: "CurrencyCode",
                principalTable: "Currencies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Currencies_CurrencyCode",
                table: "Expenses",
                column: "CurrencyCode",
                principalTable: "Currencies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
