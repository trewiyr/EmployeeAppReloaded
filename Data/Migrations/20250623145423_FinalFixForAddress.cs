using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalFixForAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Employees_Id",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Address",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId",
                table: "Address",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Employees_EmployeeId",
                table: "Address",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Employees_EmployeeId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_EmployeeId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Employees_Id",
                table: "Address",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
