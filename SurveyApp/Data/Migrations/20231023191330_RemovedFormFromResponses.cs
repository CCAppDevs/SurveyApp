using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFormFromResponses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Forms_FormId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_FormId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Responses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_FormId",
                table: "Responses",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Forms_FormId",
                table: "Responses",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "FormID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
