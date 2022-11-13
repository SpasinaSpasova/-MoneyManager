using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class AddIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("600450f8-17e8-498a-bd99-0ad81c8b3085"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("8c6feda1-c95c-4ba5-94a5-8402a483541b"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("d0345a9a-b761-4522-88a8-560cbe3b1c52"),
                column: "IsActive",
                value: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CategoryIncomes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CategoryExpenses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a79d30f9-02bf-414e-bcc9-c38281c6c469", "AQAAAAEAACcQAAAAELHadINA1Tk86fg/7NXJhk1FYixHBAtGLxGfwY55GhHqXLkK3mjyI7MoJmyfikfuhg==", "a3785ec5-5ebd-4305-97d0-8b2a7d723350" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9db47430-b3ab-447b-86dd-7b9941e0c469", "AQAAAAEAACcQAAAAEBUd26eKNtIjkL0t8tECsgdH4tI3tUkj++3rgP9BH6lxqPFOg7v472k1rWh3oLyS+Q==", "befd6c78-66bb-4c49-8e7b-cd56776c563e" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 14, 19, 34, 11, 161, DateTimeKind.Local).AddTicks(9899));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 11, 19, 19, 34, 11, 161, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 19, 19, 34, 11, 161, DateTimeKind.Local).AddTicks(5687));
        }
    }
}
