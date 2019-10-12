using Microsoft.EntityFrameworkCore.Migrations;

namespace MikesBank.Migrations
{
    public partial class changeProfessionTreeStruct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Professions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professions_ParentId",
                table: "Professions",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_Professions_ParentId",
                table: "Professions",
                column: "ParentId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professions_Professions_ParentId",
                table: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Professions_ParentId",
                table: "Professions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Professions");
        }
    }
}
