using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiPeliculasEFCore.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingGeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Birthdate", "Fortune", "Name" },
                values: new object[,]
                {
                    { 2, new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000m, "Samuel L. Jackson" },
                    { 3, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 18000m, "Robert Downey Jr." }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "InTheaters", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 2, false, new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers EndGame" },
                    { 3, false, new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: No Way Home" },
                    { 4, false, new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: Across the Spider-Verse (Part One)" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "FilmId", "Recommend" },
                values: new object[,]
                {
                    { 2, "I Love it", 2, true },
                    { 3, "A very good film", 2, true },
                    { 4, "I dont really like it", 3, false }
                });

            migrationBuilder.InsertData(
                table: "FilmGenre",
                columns: new[] { "GenresId", "filmsId" },
                values: new object[,]
                {
                    { 5, 2 },
                    { 5, 3 },
                    { 6, 4 }
                });

            migrationBuilder.InsertData(
                table: "FilmsActors",
                columns: new[] { "ActorId", "FilmId", "Character", "Order" },
                values: new object[,]
                {
                    { 2, 2, "Nick Fury", 2 },
                    { 2, 3, "Nick Fury", 1 },
                    { 3, 2, "Iron Man", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FilmGenre",
                keyColumns: new[] { "GenresId", "filmsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "FilmGenre",
                keyColumns: new[] { "GenresId", "filmsId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenre",
                keyColumns: new[] { "GenresId", "filmsId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsActors",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "FilmsActors",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "FilmsActors",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
