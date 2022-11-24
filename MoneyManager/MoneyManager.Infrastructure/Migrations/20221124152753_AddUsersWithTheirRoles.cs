using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class AddUsersWithTheirRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ff4d8b6c-2017-4adf-b3e0-3d297229ff50", "55098375-47e8-4589-816e-268d714f568b" },
                    { "ff4d8b6c-2017-4adf-b3e0-3d297229ff50", "ce00c486-6a17-41da-804f-40a576cd020d" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "682322b2-35b7-45c3-9bea-8c82f40536d6", "AQAAAAEAACcQAAAAEIafaXMpr4C18NJU9NWvVI2OssIuVwQ7I9J1bTaN3xD8+FK5TMEPliHrpj/6Cdfusw==", "5d37bd7c-53d0-4a4a-80c3-eb2cd2029f80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "001e6e34-5dd8-4043-bb5f-b2d440b7bfb5", "AQAAAAEAACcQAAAAEEO1ajkJB5HR9wTlW7zRsUcWe5WrETyIFIBL6KotF4Mbptf5EHZDoyfwJjLnxmCZWA==", "3e7cb560-4115-4aec-8971-f98e05dd5e0f" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 26, 17, 27, 52, 69, DateTimeKind.Local).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 12, 1, 17, 27, 52, 69, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 12, 1, 17, 27, 52, 69, DateTimeKind.Local).AddTicks(2088));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ff4d8b6c-2017-4adf-b3e0-3d297229ff50", "55098375-47e8-4589-816e-268d714f568b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ff4d8b6c-2017-4adf-b3e0-3d297229ff50", "ce00c486-6a17-41da-804f-40a576cd020d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76238234-3e42-4b49-8829-ff3e91e32be6", "AQAAAAEAACcQAAAAEHO2oC7hjvJkyWrOcVHv21u5ykjclYAmHntH/LznsY9uM4uWy7yZNuE4/qUrrahffg==", "bb233650-3d8a-4d88-9c8d-3289d8cb8c8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62c1d565-c567-4079-b737-ed62a4923c85", "AQAAAAEAACcQAAAAEMElAb6ZeC2FU9TxF1Y9ZGPcrcsiwq1ah8W1YOsWh4vG/eABeUMZg9lEjh6ckdbw+Q==", "de01eaeb-b423-4d46-9020-7829ac210276" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 26, 17, 19, 6, 64, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 12, 1, 17, 19, 6, 64, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 12, 1, 17, 19, 6, 64, DateTimeKind.Local).AddTicks(1736));
        }
    }
}
