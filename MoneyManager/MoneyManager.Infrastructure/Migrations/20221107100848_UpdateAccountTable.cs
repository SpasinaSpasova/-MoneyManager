using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class UpdateAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("600450f8-17e8-498a-bd99-0ad81c8b3085"),
                column: "ApplicationUserId",
                value: "ce00c486-6a17-41da-804f-40a576cd020d");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("8c6feda1-c95c-4ba5-94a5-8402a483541b"),
                column: "ApplicationUserId",
                value: "55098375-47e8-4589-816e-268d714f568b");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("d0345a9a-b761-4522-88a8-560cbe3b1c52"),
                column: "ApplicationUserId",
                value: "ce00c486-6a17-41da-804f-40a576cd020d");

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
                column: "Date",
                value: new DateTime(2022, 11, 14, 12, 8, 47, 915, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 14, 12, 8, 47, 915, DateTimeKind.Local).AddTicks(1069));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ApplicationUserId",
                table: "Accounts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_ApplicationUserId",
                table: "Accounts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_ApplicationUserId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ApplicationUserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14842509-5972-4357-8a1e-00fcd27308ba", "AQAAAAEAACcQAAAAEG63w9Gm6RsXnnz5b2ask1W2ZXmRo5yOVJP+GHt5KQK2BJgrx798dCE+BVB3NEodJg==", "add7da98-c24e-4dfa-8257-7c611138de29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1a5dd9a-70d3-4231-b81e-109f39750a48", "AQAAAAEAACcQAAAAECxR5MSVruUqNpLFfF77ZJpYXgRIRNqdwvUlHphizc04zWV3iqpAVZHmQ4hzpRPGBw==", "f8403e0c-73f8-411c-ad2a-9980056162b5" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 8, 20, 31, 37, 364, DateTimeKind.Local).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 11, 13, 20, 31, 37, 364, DateTimeKind.Local).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 11, 13, 20, 31, 37, 364, DateTimeKind.Local).AddTicks(2207));
        }
    }
}
