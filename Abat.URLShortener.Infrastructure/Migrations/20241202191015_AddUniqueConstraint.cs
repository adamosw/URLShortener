using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abat.URLShortener.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortUrlIdentifier",
                table: "ShortenedUrls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "ShortenedUrls",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_ShortenedUrls_ShortUrlIdentifier",
                table: "ShortenedUrls",
                column: "ShortUrlIdentifier",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortenedUrls_ShortUrlIdentifier",
                table: "ShortenedUrls");

            migrationBuilder.AlterColumn<string>(
                name: "ShortUrlIdentifier",
                table: "ShortenedUrls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "ShortenedUrls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
