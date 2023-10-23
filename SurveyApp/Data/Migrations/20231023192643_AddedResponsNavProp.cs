using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedResponsNavProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseType1",
                table: "Responses");

            migrationBuilder.RenameColumn(
                name: "ResponseType2",
                table: "Responses",
                newName: "TextResponse");

            migrationBuilder.AddColumn<double>(
                name: "NumericResponse",
                table: "Responses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuestionID",
                table: "Responses",
                column: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Questions_QuestionID",
                table: "Responses",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Questions_QuestionID",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_QuestionID",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "NumericResponse",
                table: "Responses");

            migrationBuilder.RenameColumn(
                name: "TextResponse",
                table: "Responses",
                newName: "ResponseType2");

            migrationBuilder.AddColumn<int>(
                name: "ResponseType1",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
