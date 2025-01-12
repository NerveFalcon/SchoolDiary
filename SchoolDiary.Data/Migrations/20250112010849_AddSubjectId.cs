using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDiary.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_Subjects_SubjectTitle",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Subjects_SubjectTitle",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "SubjectTitle",
                table: "Lessons",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_SubjectTitle",
                table: "Lessons",
                newName: "IX_Lessons_SubjectId");

            migrationBuilder.RenameColumn(
                name: "SubjectTitle",
                table: "HomeWorks",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeWorks_SubjectTitle",
                table: "HomeWorks",
                newName: "IX_HomeWorks_SubjectId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_Subjects_SubjectId",
                table: "HomeWorks",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Subjects_SubjectId",
                table: "Lessons",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_Subjects_SubjectId",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Subjects_SubjectId",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Lessons",
                newName: "SubjectTitle");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_SubjectId",
                table: "Lessons",
                newName: "IX_Lessons_SubjectTitle");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "HomeWorks",
                newName: "SubjectTitle");

            migrationBuilder.RenameIndex(
                name: "IX_HomeWorks_SubjectId",
                table: "HomeWorks",
                newName: "IX_HomeWorks_SubjectTitle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Title");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_Subjects_SubjectTitle",
                table: "HomeWorks",
                column: "SubjectTitle",
                principalTable: "Subjects",
                principalColumn: "Title",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Subjects_SubjectTitle",
                table: "Lessons",
                column: "SubjectTitle",
                principalTable: "Subjects",
                principalColumn: "Title",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
