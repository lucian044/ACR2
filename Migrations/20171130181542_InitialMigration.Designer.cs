﻿// <auto-generated />
using ACR2.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ACR2.Migrations
{
    [DbContext(typeof(ACRDbContext))]
    [Migration("20171130181542_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ACR2.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ACR2.Models.Week", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Quarter");

                    b.Property<int>("WeekNumberId");

                    b.HasKey("Id");

                    b.HasIndex("WeekNumberId");

                    b.ToTable("Week");
                });

            modelBuilder.Entity("ACR2.Models.WeekEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int>("Mon");

                    b.Property<int>("Tue");

                    b.Property<int>("Wed");

                    b.Property<int>("Thurs");

                    b.Property<int>("Fri");

                    b.Property<int?>("WeekId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("WeekId");

                    b.ToTable("WeekEntry");
                });

            modelBuilder.Entity("ACR2.Models.WeekNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("WeekNumber");
                });

            modelBuilder.Entity("ACR2.Models.Week", b =>
                {
                    b.HasOne("ACR2.Models.WeekNumber", "WeekNumber")
                        .WithMany()
                        .HasForeignKey("WeekNumberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ACR2.Models.WeekEntry", b =>
                {
                    b.HasOne("ACR2.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ACR2.Models.Week")
                        .WithMany("Entries")
                        .HasForeignKey("WeekId");
                });
#pragma warning restore 612, 618
        }
    }
}
