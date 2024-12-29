using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public partial class CinemaTicketContext : DbContext
{
    public CinemaTicketContext()
    {
    }

    public CinemaTicketContext(DbContextOptions<CinemaTicketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cast> Casts { get; set; }

    public virtual DbSet<CastCategory> CastCategories { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieCast> MovieCasts { get; set; }

    public virtual DbSet<MovieHall> MovieHalls { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog = CinemaTicket ; Integrated Security = SSPI ; TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cast__3214EC0795D41D3B");

            entity.ToTable("Cast");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CastCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cast_Cat__3214EC079638E662");

            entity.ToTable("Cast_Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07148DE582");

            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.Movies).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCategory",
                    r => r.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Movie_Cat__Movie__4F7CD00D"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Movie_Cat__Categ__4E88ABD4"),
                    j =>
                    {
                        j.HasKey("CategoryId", "MovieId").HasName("PK__Movie_Ca__ADB4134A9ABE5F85");
                        j.ToTable("Movie_Category");
                    });
        });

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cinema__3214EC0704843719");

            entity.ToTable("Cinema");

            entity.Property(e => e.Image)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hall__3214EC07A32B27D3");

            entity.ToTable("Hall");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie__3214EC07F53EC936");

            entity.ToTable("Movie");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Duration).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Image)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MovieCast>(entity =>
        {
            entity.HasKey(e => new { e.CastId, e.MovieId }).HasName("PK__Movie_Ca__DC1C007D05758AEE");

            entity.ToTable("Movie_Cast");

            entity.HasOne(d => d.Cast).WithMany(p => p.MovieCasts)
                .HasForeignKey(d => d.CastId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Cas__CastI__52593CB8");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieCasts)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Cas__Movie__534D60F1");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.MovieCasts)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK__Movie_Cast__Type__5441852A");
        });

        modelBuilder.Entity<MovieHall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie_Ha__3214EC07F8B130CD");

            entity.ToTable("Movie_Hall");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Hall).WithMany(p => p.MovieHalls)
                .HasForeignKey(d => d.HallId)
                .HasConstraintName("FK__Movie_Hal__HallI__44FF419A");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieHalls)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Movie_Hal__Movie__45F365D3");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schedule__3214EC07C575AD28");

            entity.ToTable("Schedule");

            entity.HasIndex(e => new { e.Year, e.Week }, "UQ__Schedule__1C92361857841576").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Cinema).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("FK__Schedule__Cinema__3A81B327");

            entity.HasMany(d => d.Movies).WithMany(p => p.Schedules)
                .UsingEntity<Dictionary<string, object>>(
                    "ScheduleMovie",
                    r => r.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Schedule___Movie__403A8C7D"),
                    l => l.HasOne<Schedule>().WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Schedule___Sched__3F466844"),
                    j =>
                    {
                        j.HasKey("ScheduleId", "MovieId").HasName("PK__Schedule__28377208C4205B7D");
                        j.ToTable("Schedule_Movie");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
