using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NationalBank.Migrations
{
    /// <inheritdoc />
    public partial class SeedBranchesAndManagers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "hassan.mahmoud@nationalbank.com", "Hassan Mahmoud", new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011111111" },
                    { 2, "salma.adel@nationalbank.com", "Salma Adel", new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01022222222" }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Code", "Address", "ManagerId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "ALX-01", "102 Main St, Alexandria", 2, "Alexandria Branch", "0129841284" },
                    { "CAI-01", "123 Main St, Cairo", 1, "Main Branch", "01235548884" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Code",
                keyValue: "ALX-01");

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Code",
                keyValue: "CAI-01");

            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
