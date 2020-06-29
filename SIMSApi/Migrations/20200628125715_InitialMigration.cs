using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIMSApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenderName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserFullName = table.Column<string>(maxLength: 100, nullable: true, defaultValueSql: "(N'FirstName')"),
                    UserName = table.Column<string>(maxLength: 100, nullable: true, defaultValueSql: "(N'userName')"),
                    UserPassword = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "((1234))"),
                    UserImageUrl = table.Column<string>(nullable: true),
                    UserGender = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInformation_UserInformation",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInformation_UserInformation1",
                        column: x => x.UpdatedBy,
                        principalTable: "UserInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInformation_Gender",
                        column: x => x.UserGender,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_CreatedBy",
                table: "UserInformation",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_UpdatedBy",
                table: "UserInformation",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_UserGender",
                table: "UserInformation",
                column: "UserGender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInformation");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
