using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSurveys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResponseID",
                table: "Surveys",
                newName: "QuestionaireId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AdministeredDate",
                table: "Surveys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Instructor",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_SurveyId",
                table: "Responses",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Surveys_SurveyId",
                table: "Responses",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Surveys_SurveyId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_SurveyId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "AdministeredDate",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Instructor",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Responses");

            migrationBuilder.RenameColumn(
                name: "QuestionaireId",
                table: "Surveys",
                newName: "ResponseID");
        }
    }
}
