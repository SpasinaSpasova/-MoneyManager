using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class EditCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c363534a-8012-49a0-a871-7ffe182b10a2", "AQAAAAEAACcQAAAAEJZ4seE3TP/TKyZKPuICZlxKWQ7GtkSPJCJ5wJuvyXBmGI9pIbzE2pzUwsdsTFDWIQ==", "0d4803b6-6500-462c-9f50-0ddf99bfa44c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c48e944-bf41-4bf3-a2b9-d6003d3d011f", "AQAAAAEAACcQAAAAEF7MtLettGK8WMdiriEejkYCjP7GhZSHxy0R2wRdfAXZCFiJ1vuBWPFL3HTfSr5ipQ==", "1ef0ed9a-19dd-4528-aa7f-859937695778" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 19, 14, 25, 0, 417, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 11, 24, 14, 25, 0, 416, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 24, 14, 25, 0, 416, DateTimeKind.Local).AddTicks(9047));
        }
    }
}
