using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbef49f5-2698-4f61-88ce-ea30e206ab89", "AQAAAAEAACcQAAAAEBdyz8RcRgptxffZuM6e+xYh77qPEegs2hP//1yu/yKtKNYhjubpe/6f3tmdss2QDQ==", "5a563bb6-f874-4c97-8c76-017dba875d5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8d4ce3a-070b-4199-b237-94dea509d77d", "AQAAAAEAACcQAAAAEALJtLifaGNxMiiJMqL5yH+kUDOqFBNwRv0BIJVqy4+tfTIDZolpt4969q70Nk1W5g==", "4a88e131-7f76-4b55-88eb-f49d7feb6b2d" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 8, 15, 17, 55, 621, DateTimeKind.Local).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 13, 15, 17, 55, 621, DateTimeKind.Local).AddTicks(5887));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96c2e1c2-c468-4df1-97df-245c40a33710", "AQAAAAEAACcQAAAAEM09SspBsZEGt3ZDfuxFEf6RH6/yVQz5bbct4L5d5LN7rhEt3/CBn6G1170HA2u9ag==", "5c7badc4-a3e3-48e1-86c1-200aa166faf6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84f6c7fb-5199-4333-8269-17c49660195f", "AQAAAAEAACcQAAAAEFx5dFQ19k2mz9DopbscUndGxYV0KhwnkuZsnGi/NjhLBZHCON4+RJpLrh1U5z39nA==", "e5a68e6e-7023-43bf-a54f-5dcced35ae7e" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 8, 14, 46, 35, 164, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 13, 14, 46, 35, 164, DateTimeKind.Local).AddTicks(8945));
        }
    }
}
