using ClasesPryca.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPryca.Modelos.Static
{
    public static class DBPryca
    {
        private static PrycaContext _contexto = new PrycaContext();
		public static List<Oferta> Ofertas { get; set; } = new List<Oferta>();
		public static List<Producto> Productos { get; set; } = new List<Producto>();
		public static PrycaContext Contexto { get => _contexto; }
		public static string TipoPrecioUnidad { get; } = "porUnidad";
		public static string TipoPrecioVariable { get; } = "variable";
		public static List<string> ListaTiposPrecios { get; } = new List<string> { TipoPrecioUnidad, TipoPrecioVariable };
	}
}
