﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLTV_TKPM.Data;

#nullable disable

namespace QLTV_TKPM.Migrations
{
    [DbContext(typeof(QLTV_TKPMContext))]
    [Migration("20221101023312_InitUpdateSach")]
    partial class InitUpdateSach
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QLTV_TKPM.Models.Docgia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("Daxoa")
                        .HasColumnType("bit");

                    b.Property<string>("Diachi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hoten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiDocGiaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ngaylapthe")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Ngaysinh")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LoaiDocGiaId");

                    b.ToTable("Docgia");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Loaidocgia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TenLoaidocgia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Loaidocgia");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Phieumuonchitiet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("Daxoa")
                        .HasColumnType("bit");

                    b.Property<int>("MaSachId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaSachId");

                    b.ToTable("Phieumuonchitiet");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Phieumuonsach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("Daxoa")
                        .HasColumnType("bit");

                    b.Property<int>("MaDocGiaId")
                        .HasColumnType("int");

                    b.Property<int>("MaPhieuMuonChiTietId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayMuon")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MaDocGiaId");

                    b.HasIndex("MaPhieuMuonChiTietId");

                    b.ToTable("Phieumuonsach");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Sach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("Daxoa")
                        .HasColumnType("bit");

                    b.Property<int?>("NamXb")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("Ngaynhap")
                        .HasColumnType("datetime2");

                    b.Property<string>("NhaXb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tacgia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tensach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheloaisachId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TheloaisachId");

                    b.ToTable("Sach");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Soluongsachmuon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Ngaymuontoida")
                        .HasColumnType("int");

                    b.Property<int>("Soluongsachmuontoida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Soluongsachmuon");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Theloaisach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tentheloaisach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Theloaisach");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Thoihanthe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Sothang")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Thoihanthe");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Tuoidocgia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("TuoiMax")
                        .HasColumnType("int");

                    b.Property<int>("TuoiMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tuoidocgia");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Docgia", b =>
                {
                    b.HasOne("QLTV_TKPM.Models.Loaidocgia", "LoaiDocGia")
                        .WithMany()
                        .HasForeignKey("LoaiDocGiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiDocGia");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Phieumuonchitiet", b =>
                {
                    b.HasOne("QLTV_TKPM.Models.Sach", "MaSach")
                        .WithMany()
                        .HasForeignKey("MaSachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaSach");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Phieumuonsach", b =>
                {
                    b.HasOne("QLTV_TKPM.Models.Docgia", "MaDocGia")
                        .WithMany()
                        .HasForeignKey("MaDocGiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLTV_TKPM.Models.Phieumuonchitiet", "MaPhieuMuonChiTiet")
                        .WithMany()
                        .HasForeignKey("MaPhieuMuonChiTietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaDocGia");

                    b.Navigation("MaPhieuMuonChiTiet");
                });

            modelBuilder.Entity("QLTV_TKPM.Models.Sach", b =>
                {
                    b.HasOne("QLTV_TKPM.Models.Theloaisach", "Theloaisach")
                        .WithMany()
                        .HasForeignKey("TheloaisachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theloaisach");
                });
#pragma warning restore 612, 618
        }
    }
}