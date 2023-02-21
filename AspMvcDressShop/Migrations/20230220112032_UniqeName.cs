using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspMvcDressShop.Migrations
{
    /// <inheritdoc />
    public partial class UniqeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dresses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Dresses_Name",
                table: "Dresses",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dresses_Name",
                table: "Dresses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
