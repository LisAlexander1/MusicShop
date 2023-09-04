using Microsoft.EntityFrameworkCore.Migrations;
using MusicShop.Models;

#nullable disable

namespace MusicShop.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Musician", "FirstName", new Musician());
            migrationBuilder.InsertData("Musician", "FirstName", "Петя");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiskRecords");

            migrationBuilder.DropTable(
                name: "EnsembleMembership");

            migrationBuilder.DropTable(
                name: "MusicAuthors");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MusicVersions");

            migrationBuilder.DropTable(
                name: "disk");

            migrationBuilder.DropTable(
                name: "Musician");

            migrationBuilder.DropTable(
                name: "Ensemble");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "SellerCompany");
        }
    }
}
