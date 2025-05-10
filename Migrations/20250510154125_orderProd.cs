using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMKStore.Migrations
{
    /// <inheritdoc />
    public partial class orderProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f6ccac3f-6263-4635-a8a0-d5e835d562c2"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[] { new Guid("9cfe5167-5456-4079-8172-02755cb7b0dc"), "admin@mail.ru", "Admin", "$2a$11$f9b54I20ZXnWokGHnyycguqz3jAVvY3IdB8M5CRSVGTNuaj0ahRRS", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9cfe5167-5456-4079-8172-02755cb7b0dc"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[] { new Guid("f6ccac3f-6263-4635-a8a0-d5e835d562c2"), "admin@mail.ru", "Admin", "$2a$11$nwQNijz4KpMeFW.W6wQN9OWvCsSOKHy8io8Pl6t.RVqHbDSmBIb7u", "Admin" });
        }
    }
}
