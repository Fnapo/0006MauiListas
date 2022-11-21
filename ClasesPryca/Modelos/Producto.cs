using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClasesPryca.Modelos
{
    [Table("producto")]
    public partial class Producto
    {
        [Key]
        [Column("idproducto")]
        public int Idproducto { get; set; }
        [Required]
        [Column("descripcion", TypeName = "varchar(45)")]
        public string Descripcion { get; set; }
        [Required]
        [Column("tipoPrecio", TypeName = "enum('porUnidad','variable')")]
        public string TipoPrecio { get; set; }
        [Column("precio", TypeName = "decimal(5,2)")]
        public decimal Precio { get; set; }
        [Column("fk_oferta")]
        public int FkOferta { get; set; }
        [Column("ultimaModificacion", TypeName = "datetime")]
        public DateTime UltimaModificacion { get; set; }
        [Column("cantidadLote")]
        public sbyte CantidadLote { get; set; }

        [ForeignKey(nameof(FkOferta))]
        [InverseProperty(nameof(Oferta.Producto))]
        public virtual Oferta FkOfertaNavigation { get; set; }
    }
}
