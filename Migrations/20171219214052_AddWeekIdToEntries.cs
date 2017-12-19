using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ACR2.Migrations
{
    public partial class AddWeekIdToEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekEntry_Week_WeekId",
                table: "WeekEntry");

            migrationBuilder.AlterColumn<int>(
                name: "WeekId",
                table: "WeekEntry",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekEntry_Week_WeekId",
                table: "WeekEntry",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekEntry_Week_WeekId",
                table: "WeekEntry");

            migrationBuilder.AlterColumn<int>(
                name: "WeekId",
                table: "WeekEntry",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_WeekEntry_Week_WeekId",
                table: "WeekEntry",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
