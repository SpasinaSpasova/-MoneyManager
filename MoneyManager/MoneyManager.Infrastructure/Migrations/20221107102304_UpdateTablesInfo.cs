using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class UpdateTablesInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "AccountId", "Date" },
                values: new object[] { new Guid("8c6feda1-c95c-4ba5-94a5-8402a483541b"), new DateTime(2022, 11, 14, 12, 23, 3, 36, DateTimeKind.Local).AddTicks(4567) });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 14, 12, 23, 3, 36, DateTimeKind.Local).AddTicks(4475));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39e3f1db-8314-4bf2-8de1-65c3b6aee575", "AQAAAAEAACcQAAAAEGtW2xkhju1vLaDe8VHk3ef1sxqjWAUWQbHEGLV1oA9NO3cUMpN7RJb08zF5U6ShZQ==", "a90b9887-9751-4ad0-8e30-3fb91d5171fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ceca5f0b-bfc8-4f94-9913-01d7832cc70e", "AQAAAAEAACcQAAAAEORy9ei9liWjP9ZO5fO/82xyGJZ7+h22IOpXHyghZguVayPSrkr7pJTGaU8pLZuISQ==", "82676971-a906-4c66-8359-ab7060108b42" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 9, 12, 8, 47, 915, DateTimeKind.Local).AddTicks(1512));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                columns: new[] { "AccountId", "Date" },
                values: new object[] { new Guid("d0345a9a-b761-4522-88a8-560cbe3b1c52"), new DateTime(2022, 11, 14, 12, 8, 47, 915, DateTimeKind.Local).AddTicks(1152) });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 14, 12, 8, 47, 915, DateTimeKind.Local).AddTicks(1069));
        }
    }
}
