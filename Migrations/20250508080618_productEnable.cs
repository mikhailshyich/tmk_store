using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMKStore.Migrations
{
    /// <inheritdoc />
    public partial class productEnable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1eaf5e4-d6e0-4d98-94ba-6e4ac7f313ad"));

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[] { new Guid("f6ccac3f-6263-4635-a8a0-d5e835d562c2"), "admin@mail.ru", "Admin", "$2a$11$nwQNijz4KpMeFW.W6wQN9OWvCsSOKHy8io8Pl6t.RVqHbDSmBIb7u", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f6ccac3f-6263-4635-a8a0-d5e835d562c2"));

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[] { new Guid("f1eaf5e4-d6e0-4d98-94ba-6e4ac7f313ad"), "admin@mail.ru", "Admin", "$2a$11$9svbVw1aT7.5whKY618Mce0sx/5zDKhhcMt3kvdU4uxitllDQAqye", "Admin" });
        }
    }
}
