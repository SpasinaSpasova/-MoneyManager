using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Infrastructure.Migrations
{
    public partial class AddUserToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dca26d61-afe6-44ba-b9fc-f4b912b8acd0", "06408ed5-1bfe-4e54-9269-b9dfce131f44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06408ed5-1bfe-4e54-9269-b9dfce131f44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "171876f9-6317-4a13-9302-25200ab4b179", "AQAAAAEAACcQAAAAEITyLB4hQ9vwMWXIovBLgL8ps2Bem0q//cJBF7VB73J1r3wjS52mXZF93mvCDGwRQA==", "a0d54a91-d95c-44e9-9992-c02dfeb3806e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90189164-9f2b-41fa-941d-cf0f8f1a1b04", "AQAAAAEAACcQAAAAEBJ2FFYhgrog/ScFNle+l2FIbu9HQZsybGoPeAi7sJ4ukM2nuNDjnSNm40QBdRyTGQ==", "a4784fe5-3b07-46f0-b7ea-63c3570b365c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0aca0fb-6953-44bd-a585-e4600df288ed", "AQAAAAEAACcQAAAAEITQyF5A+K2XlVMMPDdRJBXHcQjYP1NTNTr8HczFMRcJxvFk2/5fVNyEi8GOcomLBQ==", "e9511c76-3eb8-4bfe-8b0c-8e2fa727676d" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 28, 16, 52, 3, 771, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 12, 3, 16, 52, 3, 770, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 12, 3, 16, 52, 3, 770, DateTimeKind.Local).AddTicks(7628));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dca26d61-afe6-44ba-b9fc-f4b912b8acd0", "06408ed5-1bfe-4e54-9269-b9dfce131f44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06408ed5-1bfe-4e54-9269-b9dfce131f44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "000717cc-9d6a-4546-97b5-3803ff524151", "AQAAAAEAACcQAAAAED5Z8Zse8FDBkAa6ZbvgOgozFyDSvDJMXFEujroDtHMZulu1vVdqaUlcGFQp4UKIsA==", "46b44475-3d62-41b1-992f-fec7d19064ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55098375-47e8-4589-816e-268d714f568b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3267421b-f257-4ab3-8d9d-f2f031a052ff", "AQAAAAEAACcQAAAAEEcELr1LaYlGPrlVQwpyibaKyYAgM1XjOBT7WBPjcO0B0MFQomGf6R9iu1NKzkhlKQ==", "470f9006-ffe4-42b8-9ed5-87dd0c7cc963" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce00c486-6a17-41da-804f-40a576cd020d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97b6ceb2-4e0e-4d9f-884a-57843a915053", "AQAAAAEAACcQAAAAEKScUn9yb9HD5tFPomeihQ95uDJk5NjMXSeX7wBXlA04YNGtWTh0gzdiJXQlxB/uGQ==", "fbc6dacf-4f3f-4cc6-9b03-a158bceed96b" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                column: "Date",
                value: new DateTime(2022, 11, 28, 16, 47, 25, 882, DateTimeKind.Local).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
                column: "Date",
                value: new DateTime(2022, 12, 3, 16, 47, 25, 880, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                column: "Date",
                value: new DateTime(2022, 12, 3, 16, 47, 25, 880, DateTimeKind.Local).AddTicks(4350));
        }
    }
}
