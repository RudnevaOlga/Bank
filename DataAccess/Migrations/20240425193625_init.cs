using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "card",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "text", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    pin = table.Column<int>(type: "integer", nullable: false),
                    block = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "descriptionOfOperation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_descriptionOfOperation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "operation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    sum = table.Column<decimal>(type: "numeric", nullable: true),
                    cardId = table.Column<int>(type: "integer", nullable: false),
                    descriptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation", x => x.id);
                    table.ForeignKey(
                        name: "FK_operation_card_cardId",
                        column: x => x.cardId,
                        principalTable: "card",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_operation_cardId",
                table: "operation",
                column: "cardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "descriptionOfOperation");

            migrationBuilder.DropTable(
                name: "operation");

            migrationBuilder.DropTable(
                name: "card");
        }
    }
}
