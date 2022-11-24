using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
