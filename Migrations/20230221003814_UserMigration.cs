using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace dotnet_user_adminitration.Migrations
{
     /// <inheritdoc />
     public partial class UserMigration : Migration
     {
          /// <inheritdoc />
          protected override void Up(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.AlterDatabase()
                   .Annotation("MySQL:Charset", "utf8mb4");

               migrationBuilder.CreateTable(
                   name: "User",
                   columns: table => new
                   {
                        Id = table.Column<int>(type: "int", nullable: false)
                           .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                        Email = table.Column<string>(type: "longtext", nullable: false),
                        PasswordHash = table.Column<byte[]>(type: "longblob", nullable: false),
                        PasswordSalt = table.Column<byte[]>(type: "longblob", nullable: false),
                        CreatedAt = table.Column<string>(type: "longtext", nullable: false)
                   },
                   constraints: table =>
                   {
                        table.PrimaryKey("PK_User", x => x.Id);
                   })
                   .Annotation("MySQL:Charset", "utf8mb4");

               migrationBuilder.CreateTable(
                   name: "Media",
                   columns: table => new
                   {
                        Id = table.Column<int>(type: "int", nullable: false)
                           .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                        Path = table.Column<string>(type: "longtext", nullable: false),
                        CreatedAt = table.Column<string>(type: "longtext", nullable: false),
                        UserId = table.Column<int>(type: "int", nullable: false)
                   },
                   constraints: table =>
                   {
                        table.PrimaryKey("PK_Media", x => x.Id);
                        table.ForeignKey(
                         name: "FK_Media_User_UserId",
                         column: x => x.UserId,
                         principalTable: "User",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                   })
                   .Annotation("MySQL:Charset", "utf8mb4");

               migrationBuilder.CreateTable(
                   name: "UserDetail",
                   columns: table => new
                   {
                        Id = table.Column<int>(type: "int", nullable: false)
                           .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                        Name = table.Column<string>(type: "longtext", nullable: false),
                        Address = table.Column<string>(type: "longtext", nullable: false),
                        date_of_birth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                        Gender = table.Column<int>(type: "int", nullable: false),
                        CreatedAt = table.Column<string>(type: "longtext", nullable: false),
                        UserId = table.Column<int>(type: "int", nullable: false)
                   },
                   constraints: table =>
                   {
                        table.PrimaryKey("PK_UserDetail", x => x.Id);
                        table.ForeignKey(
                         name: "FK_UserDetail_User_UserId",
                         column: x => x.UserId,
                         principalTable: "User",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                   })
                   .Annotation("MySQL:Charset", "utf8mb4");

               migrationBuilder.CreateIndex(
                   name: "IX_Media_UserId",
                   table: "Media",
                   column: "UserId",
                   unique: true);

               migrationBuilder.CreateIndex(
                   name: "IX_UserDetail_UserId",
                   table: "UserDetail",
                   column: "UserId",
                   unique: true);
          }

          /// <inheritdoc />
          protected override void Down(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropTable(
                   name: "Media");

               migrationBuilder.DropTable(
                   name: "UserDetail");

               migrationBuilder.DropTable(
                   name: "User");
          }
     }
}
