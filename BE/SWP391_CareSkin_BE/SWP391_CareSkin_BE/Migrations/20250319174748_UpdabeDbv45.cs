﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP391_CareSkin_BE.Migrations
{
    /// <inheritdoc />
    public partial class UpdabeDbv45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogNew_Admin_AdminId",
                table: "BlogNew");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogNew_Staff_StaffId",
                table: "BlogNew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogNew",
                table: "BlogNew");

            migrationBuilder.RenameTable(
                name: "BlogNew",
                newName: "BlogNews");

            migrationBuilder.RenameIndex(
                name: "IX_BlogNew_StaffId",
                table: "BlogNews",
                newName: "IX_BlogNews_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogNew_AdminId",
                table: "BlogNews",
                newName: "IX_BlogNews_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogNews",
                table: "BlogNews",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogNews_Admin_AdminId",
                table: "BlogNews",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogNews_Staff_StaffId",
                table: "BlogNews",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogNews_Admin_AdminId",
                table: "BlogNews");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogNews_Staff_StaffId",
                table: "BlogNews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogNews",
                table: "BlogNews");

            migrationBuilder.RenameTable(
                name: "BlogNews",
                newName: "BlogNew");

            migrationBuilder.RenameIndex(
                name: "IX_BlogNews_StaffId",
                table: "BlogNew",
                newName: "IX_BlogNew_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogNews_AdminId",
                table: "BlogNew",
                newName: "IX_BlogNew_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogNew",
                table: "BlogNew",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogNew_Admin_AdminId",
                table: "BlogNew",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogNew_Staff_StaffId",
                table: "BlogNew",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId");
        }
    }
}
