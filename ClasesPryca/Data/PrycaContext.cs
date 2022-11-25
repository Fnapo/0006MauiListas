using System;
using ClasesMysql;
using ClasesPryca.Modelos;
using ConfiguracionGlobal;
using ConfiguracionGlobal.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClasesPryca.Data
{
    public partial class PrycaContext : DbContext
    {
        public PrycaContext()
        {
        }

        public PrycaContext(DbContextOptions<PrycaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Oferta> Oferta { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
				Opciones opciones = ConfiguracionLocal.VerOpciones();
                string cadenaConexion = ConexionMysql.CrearCadenaConexion(opciones.Servidor, opciones.Puerto, opciones.Usuario, opciones.Password, opciones.BaseDatos);

				optionsBuilder.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion));
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.Idoferta)
                    .HasName("PRIMARY");

                entity.Property(e => e.Cantidad).HasComment("El porcentage a descontar.");

                entity.Property(e => e.Descripcion)
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tipo)
                    .HasDefaultValueSql("'Normal'")
                    .HasComment("Normal, 4x3, 3x2, 2Unidad, 3Unidad")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UltimaModificacion)
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .HasComment("Fecha de la última modificación.")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.FkOferta)
                    .HasDatabaseName("clave_oferta_idx");

                entity.Property(e => e.CantidadLote)
                    .HasDefaultValueSql("'1'")
                    .HasComment("Las unidades que forman el producto.");

                entity.Property(e => e.Descripcion)
                    .HasComment("Pequeña descripción del producto")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkOferta)
                    .HasDefaultValueSql("'1'")
                    .HasComment("Clave externa a una oferta.");

                entity.Property(e => e.Precio).HasComment("Valor del precio por unidad, 0 si es variable");

                entity.Property(e => e.TipoPrecio)
                    .HasDefaultValueSql("'porUnidad'")
                    .HasComment("Tipo de precio: 1 por unidad, 2 variable")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UltimaModificacion)
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .HasComment("Fecha de la última modificación.")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.FkOfertaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.FkOferta)
                    .HasConstraintName("clave_oferta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
