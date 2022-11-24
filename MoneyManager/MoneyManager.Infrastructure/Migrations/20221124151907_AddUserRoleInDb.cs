using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class AddUserRoleInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff4d8b6c-2017-4adf-b3e0-3d297229ff50", "23cf9348-0c8e-4b74-9c27-0de02fe00463", "User", "USER" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff4d8b6c-2017-4adf-b3e0-3d297229ff50");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "226d680c-8ea8-42a2-8de6-1a0caf076993", "AQAAAAEAACcQAAAAEFWYzzxtGWn/EteV8FFv2C7rkee1aWUMyEWlF3XPmb6gHMZpxARqQ8YssmVJc86J6w==", "c6252f1f-01ed-46ef-b40c-7a67702b706d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95f2bcf9-5741-46a1-8057-615256e663c3", "AQAAAAEAACcQAAAAENZXA33BMyM4F5Dq4DN+1Urzu8ClFr0t7FlB5u5qOVmilbru3KT2YgZrAKMJgs7bzw==", "09a6db70-2b7f-415f-878f-b6c6cc346bcb" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 26, 16, 56, 55, 828, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 12, 1, 16, 56, 55, 828, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 12, 1, 16, 56, 55, 828, DateTimeKind.Local).AddTicks(3693));
        }
    }
}
