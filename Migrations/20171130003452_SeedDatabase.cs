using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ACR2.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Governance, Leadership, and Strategic Planning', 1)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Student and Other Stakeholder Focus', 2)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Faculty and Staff Focus', 3)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Educational Programs and Support', 4)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Data Driven Improvement', 5)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Chartered Nonpublic Schools', 6)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Teacher Residency', 7)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Professional or Associate License Renewal', 8)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Transportation of Pupils', 9)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Federally Funded Education Programs', 10)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Unemployment and Workers Compensation', 11)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Pupil Appraisal', 12)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Health and Health Testing', 13)");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, CategoryNumber) VALUES ('Other', 14)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Category WHERE CategoryNumber IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)");
        }
    }
}
