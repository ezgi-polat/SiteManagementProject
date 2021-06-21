using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagementProject.Migrations.ContextDBMigrations
{
    public partial class FirstPageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Menus_MenuID",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "PageMdl");

            migrationBuilder.DropTable(
                name: "MenuMdl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Pages");

            migrationBuilder.RenameTable(
                name: "Pages",
                newName: "Page");

            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "Menus",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Menus",
                newName: "MenuName");

            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "Page",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "PageID",
                table: "Page",
                newName: "PageId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Page",
                newName: "PageName");

            migrationBuilder.RenameIndex(
                name: "IX_Pages_MenuID",
                table: "Page",
                newName: "IX_Page_MenuId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Page",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Page",
                table: "Page",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Menus_MenuId",
                table: "Page",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Menus_MenuId",
                table: "Page");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Page",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Page");

            migrationBuilder.RenameTable(
                name: "Page",
                newName: "Pages");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Menus",
                newName: "MenuID");

            migrationBuilder.RenameColumn(
                name: "MenuName",
                table: "Menus",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Pages",
                newName: "MenuID");

            migrationBuilder.RenameColumn(
                name: "PageId",
                table: "Pages",
                newName: "PageID");

            migrationBuilder.RenameColumn(
                name: "PageName",
                table: "Pages",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Page_MenuId",
                table: "Pages",
                newName: "IX_Pages_MenuID");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Pages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                column: "PageID");

            migrationBuilder.CreateTable(
                name: "MenuMdl",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMdl", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "PageMdl",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageMdl", x => x.PageId);
                    table.ForeignKey(
                        name: "FK_PageMdl_MenuMdl_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MenuMdl",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageMdl_MenuId",
                table: "PageMdl",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Menus_MenuID",
                table: "Pages",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "MenuID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
