using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class UpdateCategoriesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4090de96-a5fa-4d09-90bc-197e65e11a1d", "AQAAAAEAACcQAAAAEGa/cy63xRi9gr1S2iSVPXpmFWRtBg58agbt5iyN90syLPUoopWAIEPcmcncDJwF7g==", "0b9c47d8-0cda-4d99-a0ce-8864a407dce7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84b03b44-172a-43b5-b8bb-85f8e1abb7fb", "AQAAAAEAACcQAAAAEK6UVG3JXeo0reUvzd2SZ/AwWmeP4nqlUg4YEMZRryqnBBJN94W/qJX5ibHnUUw9cw==", "de33c7a7-6c29-4ac1-a0f2-35a29994d41c" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 20, 22, 8, 4, 440, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 11, 25, 22, 8, 4, 440, DateTimeKind.Local).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 25, 22, 8, 4, 440, DateTimeKind.Local).AddTicks(116));
        }
    }
}
