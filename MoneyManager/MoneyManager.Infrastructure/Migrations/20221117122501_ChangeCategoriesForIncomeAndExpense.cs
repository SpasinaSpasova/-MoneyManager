using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class ChangeCategoriesForIncomeAndExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CategoryIncomes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CategoryExpenses");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CategoryIncomes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CategoryExpenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ed92969-d826-4809-b424-cab66065e20d", "AQAAAAEAACcQAAAAEI85Sqivu0pKPkblfLSSxSPQJ9sVKuQI9haFVJTaqNYXoMU9AykZkZodp0bKnFB8KA==", "8ecc9661-b4a7-467b-b9b3-120f694e08b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1acde79-3df0-4a8a-b918-fc3edf553181", "AQAAAAEAACcQAAAAEGjCDLuXfFEG/4EDlzj6iMSCybfB/pGcbM3VPRhe7T9taVnEVRfH2H7izSfvXxRYBA==", "ec9b774d-140b-441e-b2b0-9e15792a9b7d" });

            migrationBuilder.UpdateData(
                table: "CategoryExpenses",
                keyColumn: "Id",
                keyValue: new Guid("2751e7ab-b8ea-4c50-b2a4-9bf7a600ce0d"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "CategoryExpenses",
                keyColumn: "Id",
                keyValue: new Guid("41e3fe82-74af-4c51-bed3-6026a559873a"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "CategoryExpenses",
                keyColumn: "Id",
                keyValue: new Guid("8cd4d9ba-f2b7-4fca-811e-2e83de454910"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: new Guid("01eeec85-4e1c-4838-ad16-b113c7afd03d"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: new Guid("11a9d1a1-7153-4609-96bb-abc83181ab30"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "CategoryIncomes",
                keyColumn: "Id",
                keyValue: new Guid("c6920210-3413-42e4-854c-cadd35517bbc"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 15, 18, 2, 24, 334, DateTimeKind.Local).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 11, 20, 18, 2, 24, 334, DateTimeKind.Local).AddTicks(6123));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 20, 18, 2, 24, 334, DateTimeKind.Local).AddTicks(6042));
        }
    }
}
