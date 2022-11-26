using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class addAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e708582-5912-43a8-bbed-3a648043760a", "AQAAAAEAACcQAAAAEP5myE21WJ6CsAYHiEZNmXnkvwwwVTKmxMMm5zFFcOpBFswoup0DBavKay84iQxslg==", "6d850abb-7906-45e0-a5f6-113ee0a6c9f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be7f3b98-9169-4bc9-81bf-05235c6d010f", "AQAAAAEAACcQAAAAEJrC/wzJ8pq2Jo2AOR1keTCUoPm2O+c051iyyvRpwbHPKU1ETqOrdZTjd/SAG9Nl/g==", "97713bc8-caa3-42f7-8089-852bc0ffe5c4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "06408ed5-1bfe-4e54-9269-b9dfce131f44", 0, "03d7f865-aa27-4389-83b4-ec839a6f572c", "admin@mail.com", false, "Admin", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEDvjW8XQp9e53UulFoDdtRvtFsjv6B+k7uelIGJ5SVRwo+qi37kSJEVlGhB1itbSUg==", null, false, "9f81d80c-e80b-4092-b0f8-4d5cf8c79a65", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 28, 16, 41, 34, 30, DateTimeKind.Local).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 12, 3, 16, 41, 34, 29, DateTimeKind.Local).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 12, 3, 16, 41, 34, 29, DateTimeKind.Local).AddTicks(3719));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06408ed5-1bfe-4e54-9269-b9dfce131f44");

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
    }
}
