﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnessCenterBackend.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEntityBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bookings");
        }
    }
}
