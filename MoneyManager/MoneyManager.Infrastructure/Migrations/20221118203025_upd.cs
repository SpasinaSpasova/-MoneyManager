using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db371b43-deb3-45e8-bfb7-eb378b1de9d8", "AQAAAAEAACcQAAAAEPzwAxTmzdUah7lN9BFwBKpvhPSzony9wFMN3hlaZSXLBxOOX85wtcBTsgyFk/wQ+w==", "a967d353-fc4c-487d-b1d9-7f543c5870b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "049f9cc5-5a32-4315-872f-cfde87d1fbb1", "AQAAAAEAACcQAAAAEBNpsolPAznZbRl8joit6DpoTrD8YPWh31l+M/yFPYKrYqbh1f3q4Lf5YOl+JhsUow==", "9f2813a1-c680-4413-880d-c6de3b2af034" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 20, 22, 30, 24, 45, DateTimeKind.Local).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 11, 25, 22, 30, 24, 45, DateTimeKind.Local).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 25, 22, 30, 24, 45, DateTimeKind.Local).AddTicks(4124));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d2d5a10-daa4-43bc-a74a-7a2e84b0566d", "AQAAAAEAACcQAAAAEK2ec9SGG6aCai1E9qjp8JcADnQ2RgIvaCPmEfgF7gIG8OZd2yngGGVp7eRvrVt0kA==", "9e62e79f-def0-4232-94b7-068e93475328" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8257c509-e346-4cd1-959f-5a2da488a15b", "AQAAAAEAACcQAAAAECG024Q+qqm6uHLCznJnjUMhnigXiIgowppfmE9gh27SGITa8jOlNfcKgvGIRP4D9w==", "c14dd99c-0f30-4765-9d45-0117f86a1338" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 20, 22, 20, 43, 991, DateTimeKind.Local).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 11, 25, 22, 20, 43, 991, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 25, 22, 20, 43, 991, DateTimeKind.Local).AddTicks(112));
        }
    }
}
