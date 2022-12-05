
using ClasesPryca.Modelos;
using ClasesPryca.Modelos.Static;
using LibreriaListaCompra.Modelos;
using MisEstilos;

namespace LibreriaListaCompra.Vistas;

public partial class ComprarArticulo : ContentPage
{
	private static List<ArticuloMostrado> listaArticulosMostrados = new List<ArticuloMostrado>();

	public List<ArticuloMostrado> ListaArticulosMostrados { get; private set; }
	public static ArticuloComprado NuevoArticulo { get; set; }

	private int indiceElegido;

	public ComprarArticulo()
	{
		ListaArticulosMostrados = listaArticulosMostrados;
		InitializeComponent();

		indiceElegido = -1;
		PrepararBotones();
	}

	private void PrepararBotones()
	{
		EstilosBotones.BotonCorto(botonFiltrar);
		EstilosBotones.BotonCorto(botonElegir);
		EstilosBotones.BotonCorto(botonCancelar);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		NuevoArticulo = CrearArticuloComprado.ArticuloFinal;
		if (NuevoArticulo != null)
		{
			CrearArticuloComprado.ArticuloFinal = null;
			Navigation.PopAsync(true);
		}
	}

	public static void RellenarListaProductosMostrados(List<Producto> productos, List<Oferta> ofertas)
	{
		listaArticulosMostrados.Clear();
		for (int indice = 0; indice < productos.Count; ++indice)
		{
			Producto producto = productos[indice];
			string textoOferta = ofertas.Find(of => of.Idoferta == producto.FkOferta).Descripcion;
			ArticuloMostrado nuevo = new ArticuloMostrado(producto.Idproducto, producto.Descripcion, producto.FkOferta, textoOferta);

			listaArticulosMostrados.Add(nuevo);
		}
	}

	private void ItemElegido(object sender, SelectedItemChangedEventArgs e)
	{
		indiceElegido = e.SelectedItemIndex;
	}

	private void Cancelar(object sender, EventArgs e)
	{
		Navigation.PopAsync(true);
	}

	private void ElegirProducto(object sender, EventArgs e)
	{
		if (indiceElegido != -1)
		{
			ArticuloMostrado articulo = ListaArticulosMostrados[indiceElegido];
			Producto producto = DBPryca.Productos.Find(p => p.Idproducto == articulo.IDArticulo);
			//*
			double precio = (string.Compare(producto.TipoPrecio, DBPryca.TipoPrecioVariable, true) == 0 ? 2.14 : (double)producto.Precio);
			int unidades = (string.Compare(producto.TipoPrecio, DBPryca.TipoPrecioVariable, true) == 0 ? 1 : 2);

			NuevoArticulo = new ArticuloComprado(0, precio, producto.Descripcion, producto.TipoPrecio, producto.CantidadLote, unidades, producto.FkOferta, articulo.TextoOferta);

			Navigation.PopAsync(true);
			//*/
			//Navigation.PushAsync(new CrearArticuloComprado(articulo, producto), true);
		}
	}

	protected override bool OnBackButtonPressed()
	{
		return true;
	}
}