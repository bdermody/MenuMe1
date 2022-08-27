using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuMe1.Data.Migrations
{
    public partial class AddMenuSectionsToItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_MenuSection_MenuSectionId",
                table: "MenuItem");

            migrationBuilder.AlterColumn<int>(
                name: "MenuSectionId",
                table: "MenuItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_MenuSection_MenuSectionId",
                table: "MenuItem",
                column: "MenuSectionId",
                principalTable: "MenuSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_MenuSection_MenuSectionId",
                table: "MenuItem");

            migrationBuilder.AlterColumn<int>(
                name: "MenuSectionId",
                table: "MenuItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_MenuSection_MenuSectionId",
                table: "MenuItem",
                column: "MenuSectionId",
                principalTable: "MenuSection",
                principalColumn: "Id");
        }
    }
}
