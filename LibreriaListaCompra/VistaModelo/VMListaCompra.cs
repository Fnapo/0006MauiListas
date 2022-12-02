using ClasesPryca.Modelos.Static;
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

		public VMListaCompra()
		{
			RellenarTest();
		}

		private void RellenarTest()
		{
			for (int indice = 0; indice < 10; ++indice)
			{
				ArticuloComprado articulo = new ArticuloComprado(indice, 2.05 + 1.51 * indice, $"Tocino blanco{indice}", DBPryca.TipoPrecioVariable, 12, 1, 1, $"Sin rebajas{indice}");

				ListaCompraPryca.Add(articulo);
			}
		}
	}
}
