﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internet1_RentACar.Migrations
{
    /// <inheritdoc />
    public partial class PHOTOURLL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Cars");
        }
    }
}
