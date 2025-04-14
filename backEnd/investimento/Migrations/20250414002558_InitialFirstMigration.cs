using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace investimento.Migrations
{
    /// <inheritdoc />
    public partial class InitialFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bank",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__bank", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "investment_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__investment_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "investment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    initial_value = table.Column<double>(type: "double precision", nullable: false),
                    current_value = table.Column<double>(type: "double precision", nullable: false),
                    rentability = table.Column<string>(type: "text", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id__bank = table.Column<int>(type: "integer", nullable: false),
                    id__investment_type = table.Column<int>(type: "integer", nullable: false),
                    id__user = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__investment", x => x.id);
                    table.ForeignKey(
                        name: "FK__investment__bank",
                        column: x => x.id__bank,
                        principalTable: "bank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__investment__investment_type",
                        column: x => x.id__investment_type,
                        principalTable: "investment_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__investment__user",
                        column: x => x.id__user,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_investment_id__bank",
                table: "investment",
                column: "id__bank");

            migrationBuilder.CreateIndex(
                name: "IX_investment_id__investment_type",
                table: "investment",
                column: "id__investment_type");

            migrationBuilder.CreateIndex(
                name: "IX_investment_id__user",
                table: "investment",
                column: "id__user");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "investment");

            migrationBuilder.DropTable(
                name: "bank");

            migrationBuilder.DropTable(
                name: "investment_type");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
