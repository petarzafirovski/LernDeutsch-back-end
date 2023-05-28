using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LernDeutsch_Backend.Migrations
{
    public partial class AddQuizType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuizType",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizType",
                table: "Quizzes");
        }
    }
}
