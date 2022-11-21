using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClasesPryca.Modelos
{
    [Table("oferta")]
    public partial class Oferta
    {
        public Oferta()
        {
            Producto = new HashSet<Producto>();
        }

        [Key]
        [Column("idoferta")]
        public int Idoferta { get; set; }
        [Required]
        [Column("descripcion", TypeName = "varchar(45)")]
        public string Descripcion { get; set; }
        [Required]
        [Column("tipo", TypeName = "enum('Normal','4x3','3x2','2Unidad','3Unidad')")]
        public string Tipo { get; set; }
        [Column("cantidad")]
        public byte Cantidad { get; set; }
        [Column("ultimaModificacion", TypeName = "datetime")]
        public DateTime UltimaModificacion { get; set; }

        [InverseProperty("FkOfertaNavigation")]
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
