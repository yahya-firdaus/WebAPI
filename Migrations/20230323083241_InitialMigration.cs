using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id_user = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_verified = table.Column<bool>(type: "boolean", nullable: false),
                    profile_picture = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    id_token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    id_user = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    issued_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.id_token);
                    table.ForeignKey(
                        name: "FK_Token_User_id_user",
                        column: x => x.id_user,
                        principalTable: "User",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id_user", "address", "email", "is_verified", "name", "password", "phone_number", "profile_picture", "role", "updated_at" },
                values: new object[,]
                {
                    { "78deed47-0471-4e60-9e47-fff9f0547373", "Bandung", "admin@email.com", true, "Administrator", "$2a$11$Ti6Z8UrPJkDI0.m2JnpffO5jD/3Ed5ify4tTwrZpmrTvczzRGQ8eC", "-", "", "Administrator", null },
                    { "baa93800-c1f5-4c5d-addd-c711ac516256", "Bandung", "user@email.com", true, "User", "$2a$11$aiG26aVDrtHULHswcBriae9qF8XhPDCLSl..i1knW/4fpo2s5lC0q", "085123486759", "", "User", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Token_id_user",
                table: "Token",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_phone_number",
                table: "User",
                column: "phone_number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
