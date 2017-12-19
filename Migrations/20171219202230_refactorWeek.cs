using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ACR2.Migrations
{
    public partial class refactorWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Week_WeekNumber_WeekNumberId",
                table: "Week");

            migrationBuilder.DropIndex(
                name: "IX_Week_WeekNumberId",
                table: "Week");

            migrationBuilder.RenameColumn(
                name: "WeekNumberId",
                table: "Week",
                newName: "Year");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Week",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Week");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Week",
                newName: "WeekNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Week_WeekNumberId",
                table: "Week",
                column: "WeekNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Week_WeekNumber_WeekNumberId",
                table: "Week",
                column: "WeekNumberId",
                principalTable: "WeekNumber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
