using LibreriaListaCompra.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaListaCompra.VistaModelo
{
	public class VMListaCompra
	{
		public List<ArticuloComprado> ListaCompraPryca { get; } = new List<ArticuloComprado>();
		public int IndiceSeleccionado { get; set; } = -1;

		public VMListaCompra()
		{
			RellenarTest();
		}

		private void RellenarTest()
		{
			for (int indice = 0; indice < 10; ++indice)
			{
				ArticuloComprado articulo = new ArticuloComprado(indice, $"Tocino blanco{indice}", "variable", 12, 1, $"Sin rebajas{indice}");

				ListaCompraPryca.Add(articulo);
			}
		}
	}
}
