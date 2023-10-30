using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFormsToQuestionaires : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Forms_FormId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "Questions",
                newName: "QuestionaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_FormId",
                table: "Questions",
                newName: "IX_Questions_QuestionaireId");

            migrationBuilder.CreateTable(
                name: "Questionaire",
                columns: table => new
                {
                    QuestionaireID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionaire", x => x.QuestionaireID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Questionaire_QuestionaireId",
                table: "Questions",
                column: "QuestionaireId",
                principalTable: "Questionaire",
                principalColumn: "QuestionaireID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Questionaire_QuestionaireId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Questionaire");

            migrationBuilder.RenameColumn(
                name: "QuestionaireId",
                table: "Questions",
                newName: "FormId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuestionaireId",
                table: "Questions",
                newName: "IX_Questions_FormId");

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    FormID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.FormID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Forms_FormId",
                table: "Questions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "FormID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
