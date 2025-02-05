using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class borrowFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowedByMemberId",
                table: "Books",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowedByMemberId",
                table: "Books");
        }
    }
}
