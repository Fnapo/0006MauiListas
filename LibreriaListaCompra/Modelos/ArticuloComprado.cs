using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaListaCompra.Modelos
{
	public class ArticuloComprado
	{
		public int IDArticulo { get; set; }
		public double PrecioUnidad { get; set; }
		public string Descripcion { get; set; }
		public string TipoPrecio { get; set; }
		public int CantidadLote { get; set; }
		public int Oferta { get; set; }
		public int Unidades { get; set; }
		public double Coste { get; private set; }
		public string TextoOferta { get; set; }
		public bool Usado { get; set; }

		public ArticuloComprado(int id, double precioUnidad, string descripcion, string tipoPrecio, int cantidadLote, int unidades, int oferta, string textoOferta)
		{
			IDArticulo = id;
			PrecioUnidad = precioUnidad;
			Descripcion = descripcion;
			TipoPrecio = tipoPrecio;
			CantidadLote = cantidadLote;
			Unidades = unidades;
			Oferta = oferta;
			TextoOferta = textoOferta;
			Coste = precioUnidad * cantidadLote * unidades;
		}
	}
}
