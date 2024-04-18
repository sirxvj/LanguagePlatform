using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class medianotcollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Medias_LessonId",
                table: "Medias");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_LessonId",
                table: "Medias",
                column: "LessonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Medias_LessonId",
                table: "Medias");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_LessonId",
                table: "Medias",
                column: "LessonId");
        }
    }
}
