using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAppIntro.Migrations
{
    public partial class UserRole1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanıcılar_Roles_RoleId",
                table: "Kullanıcılar");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Kullanıcılar_UserId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Kullanıcılar_UsersId",
                table: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kullanıcılar",
                table: "Kullanıcılar");

            migrationBuilder.DropIndex(
                name: "IX_Kullanıcılar_RoleId",
                table: "Kullanıcılar");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Kullanıcılar");

            migrationBuilder.RenameTable(
                name: "Kullanıcılar",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "KullanıcıAdı",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Kullanıcılar_KullanıcıAdı",
                table: "Users",
                newName: "IX_Users_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Kullanıcılar_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UsersId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Kullanıcılar");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Kullanıcılar",
                newName: "KullanıcıAdı");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserName",
                table: "Kullanıcılar",
                newName: "IX_Kullanıcılar_KullanıcıAdı");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "Kullanıcılar",
                newName: "IX_Kullanıcılar_Email");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "Kullanıcılar",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kullanıcılar",
                table: "Kullanıcılar",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanıcılar_RoleId",
                table: "Kullanıcılar",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanıcılar_Roles_RoleId",
                table: "Kullanıcılar",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Kullanıcılar_UserId",
                table: "Roles",
                column: "UserId",
                principalTable: "Kullanıcılar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Kullanıcılar_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "Kullanıcılar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
