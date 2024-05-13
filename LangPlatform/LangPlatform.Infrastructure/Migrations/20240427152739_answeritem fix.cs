using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class answeritemfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerItems");

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerBody = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Accuracy = table.Column<bool>(type: "boolean", nullable: false),
                    QuestionItemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionItemId",
                        column: x => x.QuestionItemId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionItemId",
                table: "Answers",
                column: "QuestionItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.CreateTable(
                name: "AnswerItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Accuracy = table.Column<bool>(type: "boolean", nullable: false),
                    Answer = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerItems_Questions_QuestionItemId",
                        column: x => x.QuestionItemId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerItems_QuestionItemId",
                table: "AnswerItems",
                column: "QuestionItemId");
        }
    }
}
