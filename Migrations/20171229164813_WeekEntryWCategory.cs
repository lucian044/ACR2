using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ACR2.Migrations
{
    public partial class WeekEntryWCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WeekEntry_CategoryId",
                table: "WeekEntry",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekEntry_Category_CategoryId",
                table: "WeekEntry",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekEntry_Category_CategoryId",
                table: "WeekEntry");

            migrationBuilder.DropIndex(
                name: "IX_WeekEntry_CategoryId",
                table: "WeekEntry");
        }
    }
}
