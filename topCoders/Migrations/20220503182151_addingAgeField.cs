using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace topCoders.Migrations
{
    public partial class addingAgeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "coders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "coders");
        }
    }
}
