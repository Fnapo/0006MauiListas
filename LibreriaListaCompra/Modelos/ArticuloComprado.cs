using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaListaCompra.Modelos
{
	public class ArticuloComprado
	{
		public double PrecioUnidad { get; private set; }
		public string Descripcion { get; private set; }
		public string TipoPrecio { get; private set; }
		public int CantidadLote { get; private set; }
		public int Oferta { get; private set; }
		public string TextoOferta { get; private set; }
		public bool Usado { get; set; }

		public ArticuloComprado(double precioUnidad, string descripcion, string tipoPrecio, int cantidadLote, int oferta, string textoOferta)
		{
			PrecioUnidad = precioUnidad;
			Descripcion = descripcion;
			TipoPrecio = tipoPrecio;
			CantidadLote = cantidadLote;
			Oferta = oferta;
			TextoOferta = textoOferta;
		}
	}
}
