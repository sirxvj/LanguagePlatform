using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class questionitemfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerItems_QuestionItems_QuestionItemId",
                table: "AnswerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionItems_Medias_MediaId",
                table: "QuestionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionItems_Tests_TestId",
                table: "QuestionItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionItems",
                table: "QuestionItems");

            migrationBuilder.RenameTable(
                name: "QuestionItems",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionItems_TestId",
                table: "Questions",
                newName: "IX_Questions_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionItems_MediaId",
                table: "Questions",
                newName: "IX_Questions_MediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerItems_Questions_QuestionItemId",
                table: "AnswerItems",
                column: "QuestionItemId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Medias_MediaId",
                table: "Questions",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerItems_Questions_QuestionItemId",
                table: "AnswerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Medias_MediaId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "QuestionItems");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TestId",
                table: "QuestionItems",
                newName: "IX_QuestionItems_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_MediaId",
                table: "QuestionItems",
                newName: "IX_QuestionItems_MediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionItems",
                table: "QuestionItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerItems_QuestionItems_QuestionItemId",
                table: "AnswerItems",
                column: "QuestionItemId",
                principalTable: "QuestionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionItems_Medias_MediaId",
                table: "QuestionItems",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionItems_Tests_TestId",
                table: "QuestionItems",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
