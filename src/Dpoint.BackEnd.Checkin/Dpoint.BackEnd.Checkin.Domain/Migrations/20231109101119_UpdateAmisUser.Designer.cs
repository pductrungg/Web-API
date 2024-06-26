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
    [Migration("20231109101119_UpdateAmisUser")]
    partial class UpdateAmisUser
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
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AmisEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmisEmployeeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAmisUser")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AmisEmployee", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "NV000059",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000059",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "vanhoang.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000020",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000020",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "hoang.nguyen1@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000058",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000058",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "phu.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000057",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000057",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "hoa.duong@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000056",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000056",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "hoan.le@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000053",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000053",
                            IsAmisUser = false,
                            IsDeleted = true,
                            UserEmail = "cong.vo@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000055",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000055",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "loan.le@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000054",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000054",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "quan.vo@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000052",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000052",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "phuonganh.do@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV999903b",
                            AmisEmail = "sales_ho@dgvdigital.com",
                            AmisEmployeeCode = "NV999903b",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "sales_ho@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000016",
                            AmisEmail = "uyen.le@dgvdigital.com",
                            AmisEmployeeCode = "NV000016",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "uyen.le@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000025",
                            AmisEmail = "doanh.nguyen@dgvdigital.com",
                            AmisEmployeeCode = "NV000025",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "doanh.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000051",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000051",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "thu.pham@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000007",
                            AmisEmail = "lien.huynh@dgvdigital.com",
                            AmisEmployeeCode = "NV000007",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "lien.huynh@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000050",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000050",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "duong.vu@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000049",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000049",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "truc.bui@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000048",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000048",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "hoc.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000047",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000047",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "loi.truong@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000046",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000046",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "tuan.pham@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000045",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000045",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "hoang.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000043",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000043",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "dat.duong@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000042",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000042",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "trong.truong@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000044",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000044",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "canh.lam@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000041",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000041",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "manhdung.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000009",
                            AmisEmail = "huy.truong@dgvdigital.com",
                            AmisEmployeeCode = "NV000009",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "huy.truong@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000039",
                            AmisEmail = "",
                            AmisEmployeeCode = "NV000039",
                            IsAmisUser = false,
                            IsDeleted = true,
                            UserEmail = "nga.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV999903a",
                            AmisEmail = "sales@dgvdigital.com",
                            AmisEmployeeCode = "NV999903a",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "sales@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000000",
                            AmisEmail = "anh.chu@dgvdigital.com",
                            AmisEmployeeCode = "",
                            IsAmisUser = true,
                            IsDeleted = true,
                            UserEmail = "anh.chu@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV999999",
                            AmisEmail = "isms@dgvdigital.com",
                            AmisEmployeeCode = "NV999999",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "isms@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV999902",
                            AmisEmail = "tech@dgvdigital.com",
                            AmisEmployeeCode = "NV999902",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "tech@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV999901",
                            AmisEmail = "product@dgvdigital.com",
                            AmisEmployeeCode = "NV999901",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "product@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000021",
                            AmisEmail = "duy.ngo@dgvdigital.com",
                            AmisEmployeeCode = "NV000021",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "duy.ngo@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV999905",
                            AmisEmail = "backoffice@dgvdigital.com",
                            AmisEmployeeCode = "NV999905",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "backoffice@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV999904",
                            AmisEmail = "marketing@dgvdigital.com",
                            AmisEmployeeCode = "NV999904",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "marketing@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000012",
                            AmisEmail = "hau@dgvdigital.com",
                            AmisEmployeeCode = "NV000012",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "hau@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000022",
                            AmisEmail = "dung.nguyen@dgvdigital.com",
                            AmisEmployeeCode = "NV000022",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "dung.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000023",
                            AmisEmail = "thuy.nguyen@dgvdigital.com",
                            AmisEmployeeCode = "NV000023",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "thuy.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000014",
                            AmisEmail = "quoc.le@dgvdigital.com",
                            AmisEmployeeCode = "NV000014",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "quoc.le@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000017",
                            AmisEmail = "oanh.nguyen@dgvdigital.com",
                            AmisEmployeeCode = "NV000017",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "oanh.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000013",
                            AmisEmail = "thao@dgvdigital.com",
                            AmisEmployeeCode = "NV000013",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "thao@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000024",
                            AmisEmail = "huyen.le@dgvdigital.com",
                            AmisEmployeeCode = "NV000024",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "huyen.le@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000026",
                            AmisEmail = "son.do@dgvdigital.com",
                            AmisEmployeeCode = "NV000026",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "son.do@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000019",
                            AmisEmail = "quoc@dgvdigital.com",
                            AmisEmployeeCode = "NV000019",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "quoc@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000005",
                            AmisEmail = "hung@dgvdigital.com",
                            AmisEmployeeCode = "NV000005",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "hung@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000010",
                            AmisEmail = "hao@dgvdigital.com",
                            AmisEmployeeCode = "NV000010",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "hao@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000018",
                            AmisEmail = "hai.tran@dgvdigital.com",
                            AmisEmployeeCode = "NV000018",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "hai.tran@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000040",
                            AmisEmail = "khoa.le@dgvdigital.com",
                            AmisEmployeeCode = "NV000040",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "khoa.le@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000001",
                            AmisEmail = "tien.nguyen@dgvdigital.com",
                            AmisEmployeeCode = "NV000001",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "tien.nguyen@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000002",
                            AmisEmail = "nhan@dgvdigital.com",
                            AmisEmployeeCode = "NV000002",
                            IsAmisUser = true,
                            IsDeleted = false,
                            UserEmail = "nhan@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000061",
                            AmisEmail = "truc.pham@dgvdigital.com",
                            AmisEmployeeCode = "NV000061",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "truc.pham@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000062",
                            AmisEmail = "hoai.tran@dgvdigital.com",
                            AmisEmployeeCode = "NV000062",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "hoai.tran@dgvdigital.com"
                        },
                        new
                        {
                            Id = "TT000001",
                            AmisEmail = "tan.duong@dgvdigital.com",
                            AmisEmployeeCode = "TT000001",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "tan.duong@dgvdigital.com"
                        },
                        new
                        {
                            Id = "NV000060",
                            AmisEmail = "hieu.huynh@dgvdigital.com",
                            AmisEmployeeCode = "NV000060",
                            IsAmisUser = false,
                            IsDeleted = false,
                            UserEmail = "hieu.huynh@dgvdigital.com"
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

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.LeaveOfAbsenceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("LeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("LeaveHours")
                        .HasColumnType("float");

                    b.Property<int>("LeaveOfAbsenceId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeaveOfAbsenceId");

                    b.ToTable("LeaveOfAbsenceDetail", (string)null);
                });

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.OutOfOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalHour")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OutOfOffice", (string)null);
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

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.LeaveOfAbsenceDetail", b =>
                {
                    b.HasOne("Dpoint.BackEnd.Checkin.Domain.Entities.LeaveOfAbsence", "LeaveOfAbsence")
                        .WithMany("LeaveOfAbsenceDetails")
                        .HasForeignKey("LeaveOfAbsenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaveOfAbsence");
                });

            modelBuilder.Entity("Dpoint.BackEnd.Checkin.Domain.Entities.LeaveOfAbsence", b =>
                {
                    b.Navigation("LeaveOfAbsenceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
