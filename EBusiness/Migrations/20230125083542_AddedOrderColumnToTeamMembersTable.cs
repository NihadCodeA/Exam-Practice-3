using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBusiness.Migrations
{
    public partial class AddedOrderColumnToTeamMembersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "TeamMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "TeamMembers");
        }
    }
}
