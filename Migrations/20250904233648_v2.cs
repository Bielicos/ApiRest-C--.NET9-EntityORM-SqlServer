using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest_NET9.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelUserModel_books_projectsprojectId",
                table: "ProjectModelUserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelUserModel_users_usersUserId",
                table: "ProjectModelUserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "Projects");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "usersUserId",
                table: "ProjectModelUserModel",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "projectsprojectId",
                table: "ProjectModelUserModel",
                newName: "ProjectsProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModelUserModel_usersUserId",
                table: "ProjectModelUserModel",
                newName: "IX_ProjectModelUserModel_UsersUserId");

            migrationBuilder.RenameColumn(
                name: "projectId",
                table: "Projects",
                newName: "ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelUserModel_Projects_ProjectsProjectId",
                table: "ProjectModelUserModel",
                column: "ProjectsProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelUserModel_Users_UsersUserId",
                table: "ProjectModelUserModel",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelUserModel_Projects_ProjectsProjectId",
                table: "ProjectModelUserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelUserModel_Users_UsersUserId",
                table: "ProjectModelUserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "books");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "ProjectModelUserModel",
                newName: "usersUserId");

            migrationBuilder.RenameColumn(
                name: "ProjectsProjectId",
                table: "ProjectModelUserModel",
                newName: "projectsprojectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModelUserModel_UsersUserId",
                table: "ProjectModelUserModel",
                newName: "IX_ProjectModelUserModel_usersUserId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "books",
                newName: "projectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "projectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelUserModel_books_projectsprojectId",
                table: "ProjectModelUserModel",
                column: "projectsprojectId",
                principalTable: "books",
                principalColumn: "projectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelUserModel_users_usersUserId",
                table: "ProjectModelUserModel",
                column: "usersUserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
