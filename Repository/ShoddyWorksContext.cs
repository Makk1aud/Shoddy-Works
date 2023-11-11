using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShoddyWorks.WebApi.DbModels;

namespace ShoddyWorks.WebApi.Models;

public partial class ShoddyWorksContext : DbContext
{
    public ShoddyWorksContext()
    {
    }

    public ShoddyWorksContext(DbContextOptions<ShoddyWorksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Clientorder> Clientorders { get; set; }

    public virtual DbSet<Mentor> Mentors { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Offertype> Offertypes { get; set; }

    public virtual DbSet<Orderstatus> Orderstatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Data Source=DESKTOP-RN4PEHE;User Id=oleg;Password=UAZ9233;Database=shoddy_works;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.Login, "login").IsUnique();

            entity.HasIndex(e => e.RefClientId, "ref_client_id");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.RefClientId).HasColumnName("ref_client_id");
            entity.Property(e => e.SocMedia)
                .HasMaxLength(150)
                .HasColumnName("soc_media");

            entity.HasOne(d => d.RefClient).WithMany(p => p.InverseRefClient)
                .HasForeignKey(d => d.RefClientId)
                .HasConstraintName("client_ibfk_1");
        });

        modelBuilder.Entity<Clientorder>(entity =>
        {
            entity.HasKey(e => e.ClOrderId).HasName("PRIMARY");

            entity.ToTable("clientorder");

            entity.HasIndex(e => e.ClientId, "FK_client_id_Offer");

            entity.HasIndex(e => e.MentorId, "FK_mentor_id_Offer");

            entity.HasIndex(e => e.OfferId, "FK_offer_id_Offer");

            entity.HasIndex(e => e.OrderStId, "FK_order_st_id_Offer");

            entity.Property(e => e.ClOrderId).HasColumnName("cl_order_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.MentorId).HasColumnName("mentor_id");
            entity.Property(e => e.OfferId).HasColumnName("offer_id");
            entity.Property(e => e.OrderStId).HasColumnName("order_st_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Client).WithMany(p => p.Clientorders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_client_id_Offer");

            entity.HasOne(d => d.Mentor).WithMany(p => p.Clientorders)
                .HasForeignKey(d => d.MentorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mentor_id_Offer");

            entity.HasOne(d => d.Offer).WithMany(p => p.Clientorders)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_offer_id_Offer");

            entity.HasOne(d => d.OrderSt).WithMany(p => p.Clientorders)
                .HasForeignKey(d => d.OrderStId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_st_id_Offer");
        });

        modelBuilder.Entity<Mentor>(entity =>
        {
            entity.HasKey(e => e.MentorId).HasName("PRIMARY");

            entity.ToTable("mentor");

            entity.HasIndex(e => e.Login, "login").IsUnique();

            entity.HasIndex(e => e.Phone, "phone").IsUnique();

            entity.Property(e => e.MentorId).HasColumnName("mentor_id");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");
            entity.Property(e => e.SocMedia)
                .HasMaxLength(150)
                .HasColumnName("soc_media");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.OfferId).HasName("PRIMARY");

            entity.ToTable("offer");

            entity.HasIndex(e => e.OfferTypeId, "FK_offer_type_id_Offer");

            entity.Property(e => e.OfferId).HasColumnName("offer_id");
            entity.Property(e => e.OfferDesc)
                .HasMaxLength(150)
                .HasColumnName("offer_desc");
            entity.Property(e => e.OfferPrice)
                .HasPrecision(10)
                .HasColumnName("offer_price");
            entity.Property(e => e.OfferTitle)
                .HasMaxLength(50)
                .HasColumnName("offer_title");
            entity.Property(e => e.OfferTypeId).HasColumnName("offer_type_id");
            entity.Property(e => e.PublishDate)
                .HasColumnType("datetime")
                .HasColumnName("publish_date");

            entity.HasOne(d => d.OfferType).WithMany(p => p.Offers)
                .HasForeignKey(d => d.OfferTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_offer_type_id_Offer");
        });

        modelBuilder.Entity<Offertype>(entity =>
        {
            entity.HasKey(e => e.OfferTypeId).HasName("PRIMARY");

            entity.ToTable("offertype");

            entity.Property(e => e.OfferTypeId).HasColumnName("offer_type_id");
            entity.Property(e => e.TypeTitle)
                .HasMaxLength(50)
                .HasColumnName("type_title");
        });

        modelBuilder.Entity<Orderstatus>(entity =>
        {
            entity.HasKey(e => e.OrderStId).HasName("PRIMARY");

            entity.ToTable("orderstatus");

            entity.Property(e => e.OrderStId).HasColumnName("order_st_id");
            entity.Property(e => e.StatusTitle)
                .HasMaxLength(30)
                .HasColumnName("status_title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
