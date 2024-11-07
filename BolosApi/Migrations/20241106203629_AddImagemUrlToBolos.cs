using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolosApi.Migrations
{
    /// <inheritdoc />
    public partial class AddImagemUrlToBolos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Bolos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Bolos");
        }
    }
}
