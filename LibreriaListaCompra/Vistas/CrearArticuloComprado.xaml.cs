
using ClasesPryca.Modelos;
using LibreriaListaCompra.Modelos;
using MisEstilos;

namespace LibreriaListaCompra.Vistas;

public partial class CrearArticuloComprado : ContentPage
{
	public ArticuloMostrado ArticuloFuente { get; private set; }
	public Producto ProductoFuente { get; private set; }
	public static ArticuloComprado ArticuloFinal { get; set; }

	public CrearArticuloComprado(ArticuloMostrado articulo, Producto producto)
	{
		ArticuloFuente = articulo;
		ProductoFuente = producto;

		InitializeComponent();

		PrepararBotones();
	}

	private void PrepararBotones()
	{
		TiposBotones.BotonCorto(botonCrear);
		TiposBotones.BotonCorto(botonCancelar);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		ArticuloFinal = null;
	}

	protected override bool OnBackButtonPressed()
	{
		return true;
	}

	private void Cancelar(object sender, EventArgs e)
	{
		Navigation.PopAsync(true);
	}
}