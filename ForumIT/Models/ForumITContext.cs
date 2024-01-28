using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ForumIT.Models
{
    public partial class ForumITContext : DbContext
    {
        public ForumITContext()
        {
        }

        public ForumITContext(DbContextOptions<ForumITContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<TblBaiViet> TblBaiViets { get; set; } = null!;
        public virtual DbSet<TblBinhLuan> TblBinhLuans { get; set; } = null!;
        public virtual DbSet<TblDaLuu> TblDaLuus { get; set; } = null!;
        public virtual DbSet<TblDisable> TblDisables { get; set; } = null!;
        public virtual DbSet<TblLoaiDd> TblLoaiDds { get; set; } = null!;
        public virtual DbSet<TblTraLoiBl> TblTraLoiBls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-04BUHHJ\\HANGUYEN;Initial Catalog=ForumIT;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<TblBaiViet>(entity =>
            {
                entity.HasKey(e => e.IdBaiViet)
                    .HasName("PK__tblBaiVi__19E8E3688DB36019");

                entity.ToTable("tblBaiViet");

                entity.Property(e => e.IdBaiViet).HasColumnName("idBaiViet");

                entity.Property(e => e.IdLdd).HasColumnName("idLDD");

                entity.Property(e => e.IdUser)
                    .HasMaxLength(450)
                    .HasColumnName("idUser");

                entity.Property(e => e.Img)
                    .HasMaxLength(200)
                    .HasColumnName("img");

                entity.Property(e => e.Ngaydang).HasColumnType("datetime");

                entity.Property(e => e.NoiDung)
                    .HasMaxLength(1000)
                    .HasColumnName("noiDung");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(20)
                    .HasColumnName("trangThai");

                entity.HasOne(d => d.IdLddNavigation)
                    .WithMany(p => p.TblBaiViets)
                    .HasForeignKey(d => d.IdLdd)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblBaiVie__idLDD__59063A47");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TblBaiViets)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblBaiVie__idUse__59FA5E80");
            });

            modelBuilder.Entity<TblBinhLuan>(entity =>
            {
                entity.HasKey(e => e.IdBinhLuan)
                    .HasName("PK__tblBinhL__A6C039614D80901D");

                entity.ToTable("tblBinhLuan");

                entity.Property(e => e.IdBinhLuan).HasColumnName("idBinhLuan");

                entity.Property(e => e.IdUser)
                    .HasMaxLength(450)
                    .HasColumnName("idUser");

                entity.Property(e => e.IdidBaiVietBl).HasColumnName("ididBaiVietBL");

                entity.Property(e => e.NgayBl)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayBL");

                entity.Property(e => e.NoiDung)
                    .HasMaxLength(300)
                    .HasColumnName("noiDung");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TblBinhLuans)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_User_BLuan");

                entity.HasOne(d => d.IdidBaiVietBlNavigation)
                    .WithMany(p => p.TblBinhLuans)
                    .HasForeignKey(d => d.IdidBaiVietBl)
                    .HasConstraintName("FK_BLuan_us");
            });

            modelBuilder.Entity<TblDaLuu>(entity =>
            {
                entity.HasKey(e => e.IdDaluu)
                    .HasName("PK__tblDaLuu__957F8CCE57F50F74");

                entity.ToTable("tblDaLuu");

                entity.Property(e => e.IdDaluu).HasColumnName("idDaluu");

                entity.Property(e => e.IdBaiVietDl).HasColumnName("idBaiVietDL");

                entity.Property(e => e.IdUser)
                    .HasMaxLength(450)
                    .HasColumnName("idUser");

                entity.HasOne(d => d.IdBaiVietDlNavigation)
                    .WithMany(p => p.TblDaLuus)
                    .HasForeignKey(d => d.IdBaiVietDl)
                    .HasConstraintName("FK_DLuu_us");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TblDaLuus)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_User_DLuu");
            });

            modelBuilder.Entity<TblDisable>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("tblDisable");

                entity.Property(e => e.FkT2).HasColumnName("FK_T2");

                entity.Property(e => e.Logtime)
                    .HasColumnType("datetime")
                    .HasColumnName("logtime");

                entity.HasOne(d => d.FkT2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkT2)
                    .HasConstraintName("FK__tblDisabl__FK_T2__4E53A1AA");
            });

            modelBuilder.Entity<TblLoaiDd>(entity =>
            {
                entity.HasKey(e => e.IdLoaiDd)
                    .HasName("PK__tblLoaiD__5BB303846C7B066A");

                entity.ToTable("tblLoaiDD");

                entity.Property(e => e.IdLoaiDd).HasColumnName("idLoaiDD");

                entity.Property(e => e.TenLoaiDd)
                    .HasMaxLength(50)
                    .HasColumnName("tenLoaiDD");
            });

            modelBuilder.Entity<TblTraLoiBl>(entity =>
            {
                entity.HasKey(e => e.IdTraloi)
                    .HasName("PK__tblTraLo__E90FFEEC330CC0F8");

                entity.ToTable("tblTraLoiBL");

                entity.Property(e => e.IdTraloi).HasColumnName("idTraloi");

                entity.Property(e => e.IdBluanTloi).HasColumnName("idBLuanTLoi");

                entity.Property(e => e.IdUser)
                    .HasMaxLength(450)
                    .HasColumnName("idUser");

                entity.Property(e => e.NgayTl)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayTL");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(300)
                    .HasColumnName("noidung");

                entity.HasOne(d => d.IdBluanTloiNavigation)
                    .WithMany(p => p.TblTraLoiBls)
                    .HasForeignKey(d => d.IdBluanTloi)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblTraLoi__idBLu__7D439ABD");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TblTraLoiBls)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblTraLoi__idUse__7C4F7684");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
