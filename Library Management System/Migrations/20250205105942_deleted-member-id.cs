using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class deletedmemberid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Members");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberID",
                table: "Members",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
