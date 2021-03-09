using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediteerApp.Data.Migrations
{
    public partial class RefactorCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CollectionId",
                table: "Meditations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Meditations_CollectionId",
                table: "Meditations",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meditations_Collections_CollectionId",
                table: "Meditations",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meditations_Collections_CollectionId",
                table: "Meditations");

            migrationBuilder.DropIndex(
                name: "IX_Meditations_CollectionId",
                table: "Meditations");

            migrationBuilder.AlterColumn<Guid>(
                name: "CollectionId",
                table: "Meditations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
