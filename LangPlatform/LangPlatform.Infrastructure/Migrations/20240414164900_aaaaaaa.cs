using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class aaaaaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Lessons_LessonId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_QuestionItems_QuestionItemId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Sections_SectionId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Sections_MediaId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_QuestionItems_MediaId",
                table: "QuestionItems");

            migrationBuilder.DropIndex(
                name: "IX_Medias_LessonId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_QuestionItemId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_SectionId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "QuestionItemId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Medias");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "Lessons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sections_MediaId",
                table: "Sections",
                column: "MediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionItems_MediaId",
                table: "QuestionItems",
                column: "MediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_MediaId",
                table: "Lessons",
                column: "MediaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Medias_MediaId",
                table: "Lessons",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Medias_MediaId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Sections_MediaId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_QuestionItems_MediaId",
                table: "QuestionItems");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_MediaId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Lessons");

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "Medias",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionItemId",
                table: "Medias",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SectionId",
                table: "Medias",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_MediaId",
                table: "Sections",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionItems_MediaId",
                table: "QuestionItems",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_LessonId",
                table: "Medias",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_QuestionItemId",
                table: "Medias",
                column: "QuestionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_SectionId",
                table: "Medias",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Lessons_LessonId",
                table: "Medias",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_QuestionItems_QuestionItemId",
                table: "Medias",
                column: "QuestionItemId",
                principalTable: "QuestionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Sections_SectionId",
                table: "Medias",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");
        }
    }
}
