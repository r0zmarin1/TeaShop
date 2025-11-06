using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TeaShopHuilanDatabaseApi.Core.Models.EfModels;

public partial class LanakaraokebarContext : DbContext
{
    public LanakaraokebarContext()
    {
    }

    public LanakaraokebarContext(DbContextOptions<LanakaraokebarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productslist> Productslists { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Reporttype> Reporttypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=lanakaraokebar", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.15-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bookings");

            entity.HasIndex(e => e.IdTable, "FK_bookings_rooms_Id");

            entity.HasIndex(e => e.IdUser, "FK_bookings_users_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.HoursCount)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");
            entity.Property(e => e.IdTable)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Table");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("Id_User");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("'0001-01-01 00:00:00'")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdTableNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdTable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bookings_rooms_Id");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bookings_users_Id");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.IdBooking, "FK_orders_bookings_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cost).HasPrecision(19, 2);
            entity.Property(e => e.IdBooking)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Booking");

            entity.HasOne(d => d.IdBookingNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdBooking)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_orders_bookings_Id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.IdCategory, "FK_products_categories_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cost).HasPrecision(19, 2);
            entity.Property(e => e.IdCategory)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Category");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_products_categories_Id");
        });

        modelBuilder.Entity<Productslist>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdProduct })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("productslists");

            entity.HasIndex(e => e.IdProduct, "FK_prosuctslists_products_Id");

            entity.Property(e => e.IdOrder)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Order");
            entity.Property(e => e.IdProduct)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Product");
            entity.Property(e => e.ProductCount)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Productslists)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_prosuctslists_orders_Id");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Productslists)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_prosuctslists_products_Id");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reports");

            entity.HasIndex(e => e.IdReportType, "FK_reports_reporttypes_Id");

            entity.HasIndex(e => e.IdUser, "FK_reports_users_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdReportType)
                .HasColumnType("int(11)")
                .HasColumnName("Id_ReportType");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("Id_User");
            entity.Property(e => e.Path).HasMaxLength(255);
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("'0001-01-01 00:00:00'")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdReportTypeNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdReportType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reports_reporttypes_Id");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reports_users_Id");
        });

        modelBuilder.Entity<Reporttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reporttypes");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tables");

            entity.HasIndex(e => e.IdStatus, "FK_rooms_statuses_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdStatus)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Status");
            entity.Property(e => e.MaxPeopleCount).HasColumnType("int(11)");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Tables)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_rooms_statuses_Id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.IdRole, "FK_users_roles_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BonusesCount).HasColumnType("int(11)");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdRole)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Role");
            entity.Property(e => e.IsBlocked)
                .HasColumnType("tinyint(4)")
                .HasColumnName("Is_Blocked");
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Patronymic).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(255);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_roles_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
