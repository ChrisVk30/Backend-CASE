﻿// <auto-generated />
using System;
using CourseEnv.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseEnv.Infrastructure.Migrations
{
    [DbContext(typeof(CourseContext))]
    [Migration("20220922182852_ChangedTypeOfDurationToIntAndLimitedCoursePropertyLengths")]
    partial class ChangedTypeOfDurationToIntAndLimitedCoursePropertyLengths
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseEnv.Core.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseCode = "CNETIN",
                            Duration = 5,
                            Title = "Programming C#"
                        },
                        new
                        {
                            CourseId = 2,
                            CourseCode = "ECMASWN",
                            Duration = 2,
                            Title = "ECMAscript – What’s new"
                        },
                        new
                        {
                            CourseId = 3,
                            CourseCode = "QSQLS",
                            Duration = 5,
                            Title = "Querying SQL Server"
                        },
                        new
                        {
                            CourseId = 4,
                            CourseCode = "JPA",
                            Duration = 2,
                            Title = "Java Persistence API"
                        },
                        new
                        {
                            CourseId = 5,
                            CourseCode = "SPAVUE",
                            Duration = 3,
                            Title = "Building a SPA with Vuejs"
                        },
                        new
                        {
                            CourseId = 6,
                            CourseCode = "ASPMVC",
                            Duration = 5,
                            Title = "ASP.NET MVC"
                        });
                });

            modelBuilder.Entity("CourseEnv.Core.Entities.CourseInstance", b =>
                {
                    b.Property<int>("CourseInstanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseInstanceId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("CourseInstanceId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseInstances");

                    b.HasData(
                        new
                        {
                            CourseInstanceId = 1,
                            CourseId = 1,
                            StartDate = new DateTime(2018, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseInstanceId = 2,
                            CourseId = 2,
                            StartDate = new DateTime(2018, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseInstanceId = 3,
                            CourseId = 3,
                            StartDate = new DateTime(2018, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseInstanceId = 4,
                            CourseId = 4,
                            StartDate = new DateTime(2018, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseInstanceId = 5,
                            CourseId = 5,
                            StartDate = new DateTime(2018, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseInstanceId = 6,
                            CourseId = 6,
                            StartDate = new DateTime(2018, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CourseEnv.Core.Entities.CourseInstance", b =>
                {
                    b.HasOne("CourseEnv.Core.Entities.Course", "Course")
                        .WithMany("CourseInstances")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseEnv.Core.Entities.Course", b =>
                {
                    b.Navigation("CourseInstances");
                });
#pragma warning restore 612, 618
        }
    }
}