﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMKStore.Migrations
{
    /// <inheritdoc />
    public partial class SrcImageProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SrcImageProduct",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SrcImageProduct",
                table: "Products");
        }
    }
}
