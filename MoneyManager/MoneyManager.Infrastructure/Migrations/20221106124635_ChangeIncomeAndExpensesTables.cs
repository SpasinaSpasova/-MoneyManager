using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class ChangeIncomeAndExpensesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7faa34de-9eef-4411-b050-f8e1aba1a52f", "AQAAAAEAACcQAAAAEN7rFcyNznAA/5Ux/CBGYLCrkdZ06OPDixkXg5d4Un8cfXm0hjUDZ+hacDxK2kTBFA==", "e7c9ac44-e28d-4a5f-aa2c-6e984a5c91e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6805f927-9c58-415a-87a7-2e3e0ea0a4ba", "AQAAAAEAACcQAAAAEItEQNte3JqH65WphTr6qG0H1IvGKE3vhX0ernKY1cZMfX2Rr0iNO8dOcwlbmefb5Q==", "a5af44aa-f3e3-45b3-ab63-a0f94e327587" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 8, 13, 28, 9, 630, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 13, 13, 28, 9, 630, DateTimeKind.Local).AddTicks(4755));
        }
    }
}
