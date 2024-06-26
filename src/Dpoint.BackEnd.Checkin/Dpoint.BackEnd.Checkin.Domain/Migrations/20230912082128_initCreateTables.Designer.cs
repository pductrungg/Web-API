﻿// <auto-generated />
using System;
using Dpoint.BackEnd.Checkin.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dpoint.BackEnd.Checkin.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230912082128_initCreateTables")]
    partial class initCreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.AmisDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AmisDeptCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmisDeptEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmisDeptEmployeeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InternalDeptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AmisDepartment", (string)null);
                });

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.AmisEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AmisEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmisEmployeeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AmisEmployee", (string)null);
                });

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.CheckInOut", b =>
                {
                    b.Property<int>("MachineNo")
                        .HasColumnType("int");

                    b.Property<string>("NewType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStr")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserEnrollNumber")
                        .HasColumnType("int");

                    b.Property<int>("WorkCode")
                        .HasColumnType("int");

                    b.ToTable("CheckInOut", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.LeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("LeaveFrom")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeaveReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LeaveTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TotalLeaveHour")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LeaveRequest", (string)null);
                });

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.RelationDept", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DeptCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LevelID")
                        .HasColumnType("int");

                    b.Property<int>("RelationID")
                        .HasColumnType("int");

                    b.Property<int>("TempID")
                        .HasColumnType("int");

                    b.Property<int>("TempRelationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("RelationDept", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.UserInfo", b =>
                {
                    b.Property<int>("UserEnrollNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserEnrollNumber"), 1L, 1);

                    b.Property<string>("UserCalledName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserIDD")
                        .HasColumnType("int");

                    b.HasKey("UserEnrollNumber");

                    b.ToTable("UserInfo", null, t => t.ExcludeFromMigrations());
                });
#pragma warning restore 612, 618
        }
    }
}
