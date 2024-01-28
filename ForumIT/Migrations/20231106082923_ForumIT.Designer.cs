﻿// <auto-generated />
using System;
using ForumIT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumIT.Migrations
{
    [DbContext(typeof(ForumITContext))]
    [Migration("20231106082923_ForumIT")]
    partial class ForumIT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("ForumIT.Models.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ForumIT.Models.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("ForumIT.Models.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ForumIT.Models.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("ForumIT.Models.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("ForumIT.Models.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ForumIT.Models.TblBaiViet", b =>
                {
                    b.Property<int>("IdBaiViet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idBaiViet");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBaiViet"), 1L, 1);

                    b.Property<int?>("IdLdd")
                        .HasColumnType("int")
                        .HasColumnName("idLDD");

                    b.Property<string>("IdUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idUser");

                    b.Property<string>("Img")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("img");

                    b.Property<DateTime?>("Ngaydang")
                        .HasColumnType("datetime");

                    b.Property<string>("NoiDung")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("noiDung");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("title");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("trangThai");

                    b.HasKey("IdBaiViet")
                        .HasName("PK__tblBaiVi__19E8E3687F7E09E1");

                    b.HasIndex("IdLdd");

                    b.HasIndex("IdUser");

                    b.ToTable("tblBaiViet", (string)null);
                });

            modelBuilder.Entity("ForumIT.Models.TblBinhLuan", b =>
                {
                    b.Property<int>("IdBinhLuan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idBinhLuan");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBinhLuan"), 1L, 1);

                    b.Property<string>("IdUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idUser");

                    b.Property<int?>("IdidBaiVietBl")
                        .HasColumnType("int")
                        .HasColumnName("ididBaiVietBL");

                    b.Property<DateTime?>("NgayBl")
                        .HasColumnType("datetime")
                        .HasColumnName("NgayBL");

                    b.Property<string>("NoiDung")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("noiDung");

                    b.HasKey("IdBinhLuan")
                        .HasName("PK__tblBinhL__A6C039614C5DFB6C");

                    b.ToTable("tblBinhLuan", (string)null);
                });

            modelBuilder.Entity("ForumIT.Models.TblDaLuu", b =>
                {
                    b.Property<int>("IdDaluu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDaluu");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDaluu"), 1L, 1);

                    b.Property<int?>("IdBaiVietDl")
                        .HasColumnType("int")
                        .HasColumnName("idBaiVietDL");

                    b.Property<string>("IdUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idUser");

                    b.HasKey("IdDaluu")
                        .HasName("PK__tblDaLuu__957F8CCE1217A708");

                    b.ToTable("tblDaLuu", (string)null);
                });

            modelBuilder.Entity("ForumIT.Models.TblLoaiDd", b =>
                {
                    b.Property<int>("IdLoaiDd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idLoaiDD");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLoaiDd"), 1L, 1);

                    b.Property<string>("TenLoaiDd")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("tenLoaiDD");

                    b.HasKey("IdLoaiDd")
                        .HasName("PK__tblLoaiD__5BB303848F38B4E6");

                    b.ToTable("tblLoaiDD", (string)null);
                });

            modelBuilder.Entity("ForumIT.Models.TblTraLoiBl", b =>
                {
                    b.Property<int>("IdTraloi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTraloi");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTraloi"), 1L, 1);

                    b.Property<int?>("IdBluanTloi")
                        .HasColumnType("int")
                        .HasColumnName("idBLuanTLoi");

                    b.Property<string>("IdUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idUser");

                    b.Property<DateTime?>("NgayTl")
                        .HasColumnType("datetime")
                        .HasColumnName("NgayTL");

                    b.Property<string>("Noidung")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("noidung");

                    b.HasKey("IdTraloi")
                        .HasName("PK__tblTraLo__E90FFEEC5E23ED28");

                    b.HasIndex("IdBluanTloi");

                    b.HasIndex("IdUser");

                    b.ToTable("tblTraLoiBL", (string)null);
                });

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.HasOne("ForumIT.Models.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForumIT.Models.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ForumIT.Models.AspNetRoleClaim", b =>
                {
                    b.HasOne("ForumIT.Models.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ForumIT.Models.AspNetUserClaim", b =>
                {
                    b.HasOne("ForumIT.Models.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForumIT.Models.AspNetUserLogin", b =>
                {
                    b.HasOne("ForumIT.Models.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForumIT.Models.AspNetUserToken", b =>
                {
                    b.HasOne("ForumIT.Models.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForumIT.Models.TblBaiViet", b =>
                {
                    b.HasOne("ForumIT.Models.TblLoaiDd", "IdLddNavigation")
                        .WithMany("TblBaiViets")
                        .HasForeignKey("IdLdd")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__tblBaiVie__idLDD__59063A47");

                    b.HasOne("ForumIT.Models.AspNetUser", "IdUserNavigation")
                        .WithMany("TblBaiViets")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__tblBaiVie__idUse__59FA5E80");

                    b.Navigation("IdLddNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("ForumIT.Models.TblTraLoiBl", b =>
                {
                    b.HasOne("ForumIT.Models.TblBinhLuan", "IdBluanTloiNavigation")
                        .WithMany("TblTraLoiBls")
                        .HasForeignKey("IdBluanTloi")
                        .HasConstraintName("FK__tblTraLoi__idBLu__7D439ABD");

                    b.HasOne("ForumIT.Models.AspNetUser", "IdUserNavigation")
                        .WithMany("TblTraLoiBls")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__tblTraLoi__idUse__7C4F7684");

                    b.Navigation("IdBluanTloiNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("ForumIT.Models.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");
                });

            modelBuilder.Entity("ForumIT.Models.AspNetUser", b =>
                {
                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserTokens");

                    b.Navigation("TblBaiViets");

                    b.Navigation("TblTraLoiBls");
                });

            modelBuilder.Entity("ForumIT.Models.TblBinhLuan", b =>
                {
                    b.Navigation("TblTraLoiBls");
                });

            modelBuilder.Entity("ForumIT.Models.TblLoaiDd", b =>
                {
                    b.Navigation("TblBaiViets");
                });
#pragma warning restore 612, 618
        }
    }
}