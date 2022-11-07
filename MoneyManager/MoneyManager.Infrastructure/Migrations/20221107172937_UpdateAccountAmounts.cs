using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class UpdateAccountAmounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("d0345a9a-b761-4522-88a8-560cbe3b1c52"),
                column: "Amount",
                value: 330.56m);

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
                columns: new[] { "Amount", "Date" },
                values: new object[] { 120m, new DateTime(2022, 11, 14, 19, 29, 37, 80, DateTimeKind.Local).AddTicks(4855) });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                columns: new[] { "Amount", "Date" },
                values: new object[] { 120m, new DateTime(2022, 11, 14, 19, 29, 37, 80, DateTimeKind.Local).AddTicks(4765) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("d0345a9a-b761-4522-88a8-560cbe3b1c52"),
                column: "Amount",
                value: 30.56m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8acb1963-8612-46d2-a768-e1296a45277a", "AQAAAAEAACcQAAAAEF75O0SurXUmD0E2O0pnsWGZ6hj9riocaEGkD3DlsUxllVPdGgDTmdviMIWfzSOEnA==", "8eaf2426-7a5d-4602-92ef-38a827ec825b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f947feb-a7e9-4c44-b544-96e44309c572", "AQAAAAEAACcQAAAAEO2maKRm9KOTRNlnko+6LHZGCz1wEevhSe4aEDFZJQY91UDFLADDsbEmbSUkGwKnhw==", "6e3539f6-713c-4df8-8c8f-47e3c0874d38" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 9, 12, 23, 3, 36, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                columns: new[] { "Amount", "Date" },
                values: new object[] { 120.3m, new DateTime(2022, 11, 14, 12, 23, 3, 36, DateTimeKind.Local).AddTicks(4567) });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                columns: new[] { "Amount", "Date" },
                values: new object[] { 120.3m, new DateTime(2022, 11, 14, 12, 23, 3, 36, DateTimeKind.Local).AddTicks(4475) });
        }
    }
}
