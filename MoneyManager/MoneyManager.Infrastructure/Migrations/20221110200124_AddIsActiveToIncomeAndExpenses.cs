using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class AddIsActiveToIncomeAndExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Incomes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98715380-0123-4db9-9d44-f0c8659e41f2", "AQAAAAEAACcQAAAAELueGedGfzuKoU9HlFPLevsS34g0drHAjnLzEhbRDB4g/W3q5jAMiav8o838G4tG0Q==", "fa3e758c-9264-41af-a33e-99c2ee54404d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ee40221-9735-4942-af1c-2b0f55eb2ec2", "AQAAAAEAACcQAAAAELh788gJAySrEPBVNf6airHHAjU7tOXpZ/k+YioDvbh6MfavPW/HRrxSXV6lzI8l6g==", "6d78d39b-0931-479c-8bea-78679e70b741" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                columns: new[] { "Date", "IsActive" },
                values: new object[] { new DateTime(2022, 11, 12, 22, 1, 23, 537, DateTimeKind.Local).AddTicks(7459), true });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                columns: new[] { "Date", "IsActive" },
                values: new object[] { new DateTime(2022, 11, 17, 22, 1, 23, 537, DateTimeKind.Local).AddTicks(7005), true });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                columns: new[] { "Date", "IsActive" },
                values: new object[] { new DateTime(2022, 11, 17, 22, 1, 23, 537, DateTimeKind.Local).AddTicks(6919), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Expenses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d58e0ac4-eb86-42d9-b429-ebd905681edb", "AQAAAAEAACcQAAAAEC+Y9KY0osNU1Ouo5aKFmGO/fENrXC7LfC2cUux86kM+V1BSb6SUitloQjhW2+QdcQ==", "27fc4a81-1deb-4552-a3db-28c6c72bb0bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51699698-c1c3-4761-9286-9a4c5a5257da", "AQAAAAEAACcQAAAAEBpduKrxBvKtIOA4QooAwBcmzfybOB56666k5NW3CfEwA18Xn0HBbWtKmWfkprDp/g==", "87f075c3-6cc3-4392-a4c1-9c3f7c6dcfac" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 9, 19, 29, 37, 80, DateTimeKind.Local).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 11, 14, 19, 29, 37, 80, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 14, 19, 29, 37, 80, DateTimeKind.Local).AddTicks(4765));
        }
    }
}
