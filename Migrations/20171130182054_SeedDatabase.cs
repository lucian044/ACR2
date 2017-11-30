using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ACR2.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Governance, Leadership, and Strategic Planning', 1)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Student and Other Stakeholder Focus', 2)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Faculty and Staff Focus', 3)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Educational Programs and Support', 4)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Data Driven Improvement', 5)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Chartered Nonpublic Schools', 6)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Teacher Residency', 7)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Professional or Associate License Renewal', 8)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Transportation of Pupils', 9)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Federally Funded Education Programs', 10)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Unemployment and Workers Compensation', 11)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Pupil Appraisal', 12)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Health and Health Testing', 13)");
            migrationBuilder.Sql("INSERT INTO Category (Name, Number) VALUES ('Other', 14)");

            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (1)");
            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (2)");
            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (3)");
            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (4)");
            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (5)");
            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (6)");
            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (7)");
            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (8)");
            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (9)");
            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (10)");
            migrationBuilder.Sql("INSERT INTO WeekNumber (Number) VALUES (11)");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Category WHERE Number IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)");

            migrationBuilder.Sql("DELETE FROM WeekNumber WHERE Number IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)");
        }
    }
}
