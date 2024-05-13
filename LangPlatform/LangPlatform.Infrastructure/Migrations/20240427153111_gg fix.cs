using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ggfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionItemId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuestionItemId",
                table: "Answers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionItemId",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answers",
                newName: "QuestionItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                newName: "IX_Answers_QuestionItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionItemId",
                table: "Answers",
                column: "QuestionItemId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
