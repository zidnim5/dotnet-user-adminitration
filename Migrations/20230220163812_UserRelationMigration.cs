using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_user_adminitration.Migrations
{
     /// <inheritdoc />
     public partial class UserRelationMigration : Migration
     {
          /// <inheritdoc />
          protected override void Up(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.AddColumn<int>(
                   name: "UserUid",
                   table: "UserDetail",
                   type: "int",
                   nullable: false,
                   defaultValue: 0);

               migrationBuilder.AddColumn<int>(
                   name: "UserUid",
                   table: "Media",
                   type: "int",
                   nullable: false,
                   defaultValue: 0);

               migrationBuilder.CreateIndex(
                   name: "IX_UserDetail_UserUid",
                   table: "UserDetail",
                   column: "UserUid");

               migrationBuilder.CreateIndex(
                   name: "IX_Media_UserUid",
                   table: "Media",
                   column: "UserUid");

               migrationBuilder.AddForeignKey(
                   name: "FK_Media_User_UserUid",
                   table: "Media",
                   column: "UserUid",
                   principalTable: "User",
                   principalColumn: "Uid",
                   onDelete: ReferentialAction.Cascade);

               migrationBuilder.AddForeignKey(
                   name: "FK_UserDetail_User_UserUid",
                   table: "UserDetail",
                   column: "UserUid",
                   principalTable: "User",
                   principalColumn: "Uid",
                   onDelete: ReferentialAction.Cascade);
          }

          /// <inheritdoc />
          protected override void Down(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropForeignKey(
                   name: "FK_Media_User_UserUid",
                   table: "Media");

               migrationBuilder.DropForeignKey(
                   name: "FK_UserDetail_User_UserUid",
                   table: "UserDetail");

               migrationBuilder.DropIndex(
                   name: "IX_UserDetail_UserUid",
                   table: "UserDetail");

               migrationBuilder.DropIndex(
                   name: "IX_Media_UserUid",
                   table: "Media");

               migrationBuilder.DropColumn(
                   name: "UserUid",
                   table: "UserDetail");

               migrationBuilder.DropColumn(
                   name: "UserUid",
                   table: "Media");
          }
     }
}
