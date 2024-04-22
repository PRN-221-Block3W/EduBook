using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EduBook.BusinessObject.Models
{
    public partial class EduBookingContext : DbContext
    {
        public EduBookingContext()
        {
        }

        public EduBookingContext(DbContextOptions<EduBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database=EduBooking;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.Address).HasMaxLength(30);

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("User_Name");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Department_Account");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("Booking_Id");

                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasColumnName("Booking_Date");

                entity.Property(e => e.SlotId).HasColumnName("Slot_Id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Booking_Account");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SlotId)
                    .HasConstraintName("FK_Booking_SlotBooking");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.SlotId)
                    .HasName("PK_SlotBooking");

                entity.ToTable("BookingDetail");

                entity.Property(e => e.SlotId).HasColumnName("Slot_Id");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(15)
                    .HasColumnName("End_Time");

                entity.Property(e => e.RoomId).HasColumnName("Room_Id");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(15)
                    .HasColumnName("Start_Time");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingDetail_Room");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasColumnName("Comment_Id");

                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.Context).HasMaxLength(500);

                entity.Property(e => e.RoomId).HasColumnName("Room_Id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Account");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Room");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .HasColumnName("Department_Name");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(15)
                    .HasColumnName("End_Time");

                entity.Property(e => e.ImageDepartment)
                    .HasMaxLength(150)
                    .HasColumnName("Image_Department");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(15)
                    .HasColumnName("Start_Time");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.RateId);

                entity.ToTable("Rating");

                entity.Property(e => e.RateId).HasColumnName("Rate_Id");

                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.RateNumber).HasColumnName("Rate_Number");

                entity.Property(e => e.RoomId).HasColumnName("Room_Id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Account");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Room");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(30)
                    .HasColumnName("Role_Name");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.HasIndex(e => e.RoomNo, "UQ__Room__19EF81FDE72D65AA")
                    .IsUnique();

                entity.Property(e => e.RoomId).HasColumnName("Room_Id");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(50)
                    .HasColumnName("Room_Name");

                entity.Property(e => e.RoomNo).HasColumnName("Room_No");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Department");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
