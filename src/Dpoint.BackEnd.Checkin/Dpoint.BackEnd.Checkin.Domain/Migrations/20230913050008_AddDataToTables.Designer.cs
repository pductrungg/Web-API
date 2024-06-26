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
    [Migration("20230913050008_AddDataToTables")]
    partial class AddDataToTables
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmisDeptCode = "DV03",
                            AmisDeptEmail = "backoffice@dgvdigital.com",
                            AmisDeptEmployeeCode = "NV999905",
                            InternalDeptId = 2
                        },
                        new
                        {
                            Id = 2,
                            AmisDeptCode = "DV01",
                            AmisDeptEmail = "tech@dgvdigital.com",
                            AmisDeptEmployeeCode = "NV999902",
                            InternalDeptId = 4
                        },
                        new
                        {
                            Id = 3,
                            AmisDeptCode = "DV07",
                            AmisDeptEmail = "backoffice@dgvdigital.com",
                            AmisDeptEmployeeCode = "NV999905",
                            InternalDeptId = 6
                        },
                        new
                        {
                            Id = 4,
                            AmisDeptCode = "DV05",
                            AmisDeptEmail = "product@dgvdigital.com",
                            AmisDeptEmployeeCode = "NV999901",
                            InternalDeptId = 7
                        },
                        new
                        {
                            Id = 5,
                            AmisDeptCode = "DV04",
                            AmisDeptEmail = "sales@dgvdigital.com",
                            AmisDeptEmployeeCode = "NV999903a",
                            InternalDeptId = 8
                        },
                        new
                        {
                            Id = 6,
                            AmisDeptCode = "DV02",
                            AmisDeptEmail = "marketing@dgvdigital.com",
                            AmisDeptEmployeeCode = "NV999904",
                            InternalDeptId = 9
                        },
                        new
                        {
                            Id = 7,
                            AmisDeptCode = "DV06",
                            AmisDeptEmail = "backoffice@dgvdigital.com",
                            AmisDeptEmployeeCode = "NV999905",
                            InternalDeptId = 10
                        },
                        new
                        {
                            Id = 8,
                            AmisDeptCode = "DV08",
                            AmisDeptEmail = "backoffice@dgvdigital.com",
                            AmisDeptEmployeeCode = "NV999905",
                            InternalDeptId = 1
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmisEmail = "sales_ho@dgvdigital.com",
                            AmisEmployeeCode = "NV999903b",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 2,
                            AmisEmail = "sales@dgvdigital.com",
                            AmisEmployeeCode = "NV999903a",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 3,
                            AmisEmail = "isms@dgvdigital.com",
                            AmisEmployeeCode = "NV999999",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 4,
                            AmisEmail = "tech@dgvdigital.com",
                            AmisEmployeeCode = "NV999902",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 5,
                            AmisEmail = "product@dgvdigital.com",
                            AmisEmployeeCode = "NV999901",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 6,
                            AmisEmail = "duy.ngo@dgvdigital.com",
                            AmisEmployeeCode = "NV000021",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 7,
                            AmisEmail = "backoffice@dgvdigital.com",
                            AmisEmployeeCode = "NV999905",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 8,
                            AmisEmail = "marketing@dgvdigital.com",
                            AmisEmployeeCode = "NV999904",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 9,
                            AmisEmail = "hau@dgvdigital.com",
                            AmisEmployeeCode = "NV000012",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 10,
                            AmisEmail = "dung.nguyen@dgvdigital.com",
                            AmisEmployeeCode = "NV000022",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 11,
                            AmisEmail = "doanh.nguyen@dgvdigital.com",
                            AmisEmployeeCode = "NV000025",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 12,
                            AmisEmail = "thuy.nguyen@dgvdigital.com",
                            AmisEmployeeCode = "NV000023",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 13,
                            AmisEmail = "quoc.le@dgvdigital.com",
                            AmisEmployeeCode = "NV000014",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 14,
                            AmisEmail = "oanh.nguyen@dgvdigital.com",
                            AmisEmployeeCode = "NV000017",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 15,
                            AmisEmail = "thao@dgvdigital.com",
                            AmisEmployeeCode = "NV000013",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 16,
                            AmisEmail = "huyen.le@dgvdigital.com",
                            AmisEmployeeCode = "NV000024",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 17,
                            AmisEmail = "uyen.le@dgvdigital.com",
                            AmisEmployeeCode = "NV000016",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 18,
                            AmisEmail = "hoang.nguyen1@dgvdigital.com",
                            AmisEmployeeCode = "NV000020",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 19,
                            AmisEmail = "son.do @dgvdigital.com",
                            AmisEmployeeCode = "NV000026",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 20,
                            AmisEmail = "quoc@dgvdigital.com",
                            AmisEmployeeCode = "NV000019",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 21,
                            AmisEmail = "hung@dgvdigital.com",
                            AmisEmployeeCode = "NV000005",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 22,
                            AmisEmail = "huy.truong@dgvdigital.com",
                            AmisEmployeeCode = "NV000009",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 23,
                            AmisEmail = "hao@dgvdigital.com",
                            AmisEmployeeCode = "NV000010",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 24,
                            AmisEmail = "hai.tran@dgvdigital.com",
                            AmisEmployeeCode = "NV000018",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 25,
                            AmisEmail = "lien.huynh@dgvdigital.com",
                            AmisEmployeeCode = "NV000007",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 26,
                            AmisEmail = "khoa.le@dgvdigital.com",
                            AmisEmployeeCode = "NV000040",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 27,
                            AmisEmail = "tien.nguyen@dgvdigital.com",
                            AmisEmployeeCode = "NV000001",
                            IsDeleted = 0
                        },
                        new
                        {
                            Id = 28,
                            AmisEmail = "nhan@dgvdigital.com",
                            AmisEmployeeCode = "NV000002",
                            IsDeleted = 0
                        });
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

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.LeaveOfAbsence", b =>
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

                    b.ToTable("LeaveOfAbsence", (string)null);
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
