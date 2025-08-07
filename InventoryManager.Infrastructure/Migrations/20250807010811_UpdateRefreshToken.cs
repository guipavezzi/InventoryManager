using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refresh_token_users_UserId1",
                table: "refresh_token");

            migrationBuilder.DropIndex(
                name: "IX_refresh_token_UserId1",
                table: "refresh_token");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "refresh_token");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "refresh_token",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_UserId1",
                table: "refresh_token",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_token_users_UserId1",
                table: "refresh_token",
                column: "UserId1",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
