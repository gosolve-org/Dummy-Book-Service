using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoSolve.Dummy.Book.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    AmountOfPages = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookGenres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "BookGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 30, 21, 9, 46, 807, DateTimeKind.Utc).AddTicks(7020), "Narrative storytelling with imaginary characters and events.", "Fiction", new DateTime(2022, 12, 30, 21, 9, 46, 807, DateTimeKind.Utc).AddTicks(7020) },
                    { 2, new DateTime(2022, 12, 30, 21, 9, 46, 807, DateTimeKind.Utc).AddTicks(7020), "Narrative storytelling based on real events and factual information.", "Non-fiction", new DateTime(2022, 12, 30, 21, 9, 46, 807, DateTimeKind.Utc).AddTicks(7020) },
                    { 3, new DateTime(2022, 12, 30, 21, 9, 46, 807, DateTimeKind.Utc).AddTicks(7020), "Narrative storytelling involving a crime or puzzle to be solved.", "Mystery", new DateTime(2022, 12, 30, 21, 9, 46, 807, DateTimeKind.Utc).AddTicks(7020) },
                    { 4, new DateTime(2022, 12, 30, 21, 9, 46, 807, DateTimeKind.Utc).AddTicks(7020), "Narrative storytelling centered on the romantic relationships of the characters.", "Romance", new DateTime(2022, 12, 30, 21, 9, 46, 807, DateTimeKind.Utc).AddTicks(7020) },
                    { 5, new DateTime(2022, 12, 30, 21, 9, 46, 807, DateTimeKind.Utc).AddTicks(7020), "Narrative storytelling set in the future or in an alternative reality and involving scientific or technological elements.", "Science fiction", new DateTime(2022, 12, 30, 21, 9, 46, 807, DateTimeKind.Utc).AddTicks(7020) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookGenres");
        }
    }
}
