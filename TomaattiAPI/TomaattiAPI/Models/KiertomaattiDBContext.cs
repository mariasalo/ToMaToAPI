using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TomaattiAPI.Models
{
    public partial class KiertomaattiDBContext : DbContext
    {
        public KiertomaattiDBContext()
        {
        }

        public KiertomaattiDBContext(DbContextOptions<KiertomaattiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kayttaja> Kayttaja { get; set; }
        public virtual DbSet<Tuote> Tuote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server = localhost; database = TomaattiDB; trusted_connection = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kayttaja>(entity =>
            {
                entity.ToTable("kayttaja");

                entity.Property(e => e.KayttajaId).HasColumnName("kayttajaID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.KayttajaNimi)
                    .IsRequired()
                    .HasColumnName("kayttajaNimi")
                    .HasMaxLength(20);

                entity.Property(e => e.Kuvaus)
                    .HasColumnName("kuvaus")
                    .HasMaxLength(255);

                entity.Property(e => e.Puhelinnumero)
                    .HasColumnName("puhelinnumero")
                    .HasMaxLength(15);

                entity.Property(e => e.Salasana)
                    .IsRequired()
                    .HasColumnName("salasana")
                    .HasMaxLength(255);

                entity.Property(e => e.SalasanaHash)
                    .HasColumnName("salasanaHash")
                    .HasMaxLength(255);

                entity.Property(e => e.SalasanaSalt)
                    .HasColumnName("salasanaSalt")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Tuote>(entity =>
            {
                entity.ToTable("tuote");

                entity.Property(e => e.TuoteId).HasColumnName("tuoteID");

                entity.Property(e => e.Avaamattomat).HasColumnName("avaamattomat");

                entity.Property(e => e.BlobstorageLinkki)
                    .HasColumnName("blobstorageLinkki")
                    .HasMaxLength(255);

                entity.Property(e => e.Herkut).HasColumnName("herkut");

                entity.Property(e => e.Hevi).HasColumnName("hevi");

                entity.Property(e => e.Itsetehty).HasColumnName("itsetehty");

                entity.Property(e => e.Juomat).HasColumnName("juomat");

                entity.Property(e => e.KayttajaId).HasColumnName("kayttajaID");

                entity.Property(e => e.Kotitila).HasColumnName("kotitila");

                entity.Property(e => e.Kuivatuotteet).HasColumnName("kuivatuotteet");

                entity.Property(e => e.Kuva).HasColumnName("kuva");

                entity.Property(e => e.Kuvaus)
                    .HasColumnName("kuvaus")
                    .HasMaxLength(255);

                entity.Property(e => e.Kylmatuotteet).HasColumnName("kylmatuotteet");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Lkm).HasColumnName("lkm");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Mausteet).HasColumnName("mausteet");

                entity.Property(e => e.Nimi)
                    .IsRequired()
                    .HasColumnName("nimi")
                    .HasMaxLength(70);

                entity.Property(e => e.Paivays)
                    .HasColumnName("paivays")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Kayttaja)
                    .WithMany(p => p.Tuote)
                    .HasForeignKey(d => d.KayttajaId)
                    .HasConstraintName("FK_tuote_kayttaja");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
