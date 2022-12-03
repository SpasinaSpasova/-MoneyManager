using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class AddIsActiveToCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CategoryIncomes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CategoryExpenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06408ed5-1bfe-4e54-9269-b9dfce131f44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a55d3115-2392-40f4-8afa-c586aaf705df", "AQAAAAEAACcQAAAAEBxTD5+ZdMRpSr3KEgZ8tuzbygIR+1hMmfOZ9opJxWk8xtEraNWiEhHdXZD5weiCtA==", "17efee4c-12b6-4c32-b8a7-1f684078be76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0cb669d-5c37-49ec-846c-3863f2f93de8", "AQAAAAEAACcQAAAAEBKlMCznoFHogKB5jV5UoEXVpV4rQcl7EhO8m1RU67AMSF5dWNfBSojqRGtq1QDvXQ==", "f9d9df13-d601-476f-9c89-1f2d7e7f1ce1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d98cc9b-5f41-4aa9-8366-c0eb78634c48", "AQAAAAEAACcQAAAAEFV2R/+A4CqE7g3Jy9ayPHjtao912yjHK62z8TEfs1JDg3W4guGRgtkyoxaN5U5tNw==", "5d074e20-d5a3-438a-8c64-89189c735485" });

            migrationBuilder.UpdateData(
                table: "CategoryExpenses",
                keyColumn: "Id",
                keyValue: new Guid("2751e7ab-b8ea-4c50-b2a4-9bf7a600ce0d"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "CategoryExpenses",
                keyColumn: "Id",
                keyValue: new Guid("41e3fe82-74af-4c51-bed3-6026a559873a"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "CategoryExpenses",
                keyColumn: "Id",
                keyValue: new Guid("8cd4d9ba-f2b7-4fca-811e-2e83de454910"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: new Guid("01eeec85-4e1c-4838-ad16-b113c7afd03d"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: new Guid("11a9d1a1-7153-4609-96bb-abc83181ab30"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: new Guid("c6920210-3413-42e4-854c-cadd35517bbc"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 12, 5, 12, 13, 34, 647, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 12, 10, 12, 13, 34, 647, DateTimeKind.Local).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 12, 10, 12, 13, 34, 647, DateTimeKind.Local).AddTicks(5246));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CategoryIncomes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CategoryExpenses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06408ed5-1bfe-4e54-9269-b9dfce131f44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "171876f9-6317-4a13-9302-25200ab4b179", "AQAAAAEAACcQAAAAEITyLB4hQ9vwMWXIovBLgL8ps2Bem0q//cJBF7VB73J1r3wjS52mXZF93mvCDGwRQA==", "a0d54a91-d95c-44e9-9992-c02dfeb3806e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90189164-9f2b-41fa-941d-cf0f8f1a1b04", "AQAAAAEAACcQAAAAEBJ2FFYhgrog/ScFNle+l2FIbu9HQZsybGoPeAi7sJ4ukM2nuNDjnSNm40QBdRyTGQ==", "a4784fe5-3b07-46f0-b7ea-63c3570b365c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0aca0fb-6953-44bd-a585-e4600df288ed", "AQAAAAEAACcQAAAAEITQyF5A+K2XlVMMPDdRJBXHcQjYP1NTNTr8HczFMRcJxvFk2/5fVNyEi8GOcomLBQ==", "e9511c76-3eb8-4bfe-8b0c-8e2fa727676d" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 28, 16, 52, 3, 771, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 12, 3, 16, 52, 3, 770, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 12, 3, 16, 52, 3, 770, DateTimeKind.Local).AddTicks(7628));
        }
    }
}
