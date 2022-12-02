using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaListaCompra.Modelos
{
    public class ArticuloMostrado
	{
		public int IDArticulo { get; set; }
		public string Descripcion { get; set; }
		public int Oferta { get; set; }
		public string TextoOferta { get; set; }

		public ArticuloMostrado(int idArticulo, string descripcion, int oferta, string textoOferta)
		{
			IDArticulo = idArticulo;
			Descripcion = descripcion;
			Oferta = oferta;
			TextoOferta = textoOferta;
		}
	}
}
