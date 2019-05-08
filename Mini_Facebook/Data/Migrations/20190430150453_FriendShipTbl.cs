using Microsoft.EntityFrameworkCore.Migrations;

namespace Mini_Facebook.Data.Migrations
{
    public partial class FriendShipTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Friendships",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Friendships");
        }
    }
}
