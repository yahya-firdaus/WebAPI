using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelFaq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id_user",
                keyValue: "78deed47-0471-4e60-9e47-fff9f0547373");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id_user",
                keyValue: "baa93800-c1f5-4c5d-addd-c711ac516256");

            migrationBuilder.CreateTable(
                name: "Faq",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Answer = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id_user", "address", "email", "is_verified", "name", "password", "phone_number", "profile_picture", "role", "updated_at" },
                values: new object[,]
                {
                    { "ba434232-39a8-4ecc-9079-c66d15ba6bd7", "Bandung", "user@email.com", true, "User", "$2a$11$hBkF1AFeexdBVbiwet6RLu/uiSef4ZLJ53Ew/v9EldYXrBvbDSCLy", "085123486759", "", "User", null },
                    { "ca9f0f3c-59fc-4ab9-a840-73ff66923980", "Bandung", "admin@email.com", true, "Administrator", "$2a$11$vFhRZMwAUXlocyGjy/qcJugz.kmzK7xKwZ0RdniqWMYFor8b0bh/S", "-", "", "Administrator", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faq");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id_user",
                keyValue: "ba434232-39a8-4ecc-9079-c66d15ba6bd7");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id_user",
                keyValue: "ca9f0f3c-59fc-4ab9-a840-73ff66923980");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id_user", "address", "email", "is_verified", "name", "password", "phone_number", "profile_picture", "role", "updated_at" },
                values: new object[,]
                {
                    { "78deed47-0471-4e60-9e47-fff9f0547373", "Bandung", "admin@email.com", true, "Administrator", "$2a$11$Ti6Z8UrPJkDI0.m2JnpffO5jD/3Ed5ify4tTwrZpmrTvczzRGQ8eC", "-", "", "Administrator", null },
                    { "baa93800-c1f5-4c5d-addd-c711ac516256", "Bandung", "user@email.com", true, "User", "$2a$11$aiG26aVDrtHULHswcBriae9qF8XhPDCLSl..i1knW/4fpo2s5lC0q", "085123486759", "", "User", null }
                });
        }
    }
}
