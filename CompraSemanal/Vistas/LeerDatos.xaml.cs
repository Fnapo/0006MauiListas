
using ClasesPryca.Modelos;
using ClasesPryca.Modelos.Static;
using LibreriaListaCompra.Vistas;
using MisEstilos;

namespace CompraSemanal.Vistas;

public partial class LeerDatos : ContentPage
{
	private enum AvisosLectura
	{
		LecturaCorrecta,
		ErrorEnOfertas,
		ErrorEnProductos
	}

	public LeerDatos()
	{
		InitializeComponent();

		Indicador.IsRunning = true;
		BotonesInicio();
		LeerDatosArticulos();
	}

	private void BotonesInicio()
	{
		BotonSalir.IsEnabled = BotonCrear.IsEnabled = false;
	}

	private void Salir(object sender, EventArgs e)
	{
		Environment.Exit(1);
	}

	private async void LeerDatosArticulos()
	{
		AvisosLectura lecturaCorecta;

		DBPryca.Ofertas = await Task.Run(() => DBPryca.Contexto.Oferta.ToList());
		DBPryca.Productos = await Task.Run(() => DBPryca.Contexto.Producto.ToList());
		lecturaCorecta = LecturaCorrecta();
		if(lecturaCorecta == AvisosLectura.LecturaCorrecta)
		{
			ComprarArticulo.RellenarListaProductosMostrados(DBPryca.Productos, DBPryca.Ofertas);
		}
		BotonesFinal(lecturaCorecta);
		RellenarMensaje(lecturaCorecta);
	}

	private void BotonesFinal(AvisosLectura lecturaCorecta)
	{
		Indicador.IsRunning = false;
		BotonSalir.IsEnabled = true;
		BotonSalir.Style = Estilos.BotonPeligro;
		BotonCrear.IsEnabled = lecturaCorecta == AvisosLectura.LecturaCorrecta;
		BotonCrear.Style = (lecturaCorecta == AvisosLectura.LecturaCorrecta ? Estilos.BotonAvanzar : Estilos.BotonNoActivo);
	}

	private void RellenarMensaje(AvisosLectura lecturaCorecta)
	{
		Mensaje.Style = (lecturaCorecta == AvisosLectura.LecturaCorrecta ? Estilos.AvisoOK : Estilos.AvisoError);
		Mensaje.Text = (lecturaCorecta == AvisosLectura.LecturaCorrecta ? "Lectura Correcta ..." : "Error en la tabla de "
			+ (lecturaCorecta == AvisosLectura.ErrorEnOfertas ? "Ofertas ..." : "Productos ..."));
		Mensaje.IsVisible = true;
	}

	private AvisosLectura LecturaCorrecta()
	{
		if (DBPryca.Ofertas.Count <= 0)
		{
			return AvisosLectura.ErrorEnOfertas;
		}
		if (DBPryca.Productos.Count <= 0)
		{
			return AvisosLectura.ErrorEnProductos;
		}

		return AvisosLectura.LecturaCorrecta;
	}

	protected override bool OnBackButtonPressed()
	{
		return true;
	}

	private async void CrearLista(object sender, EventArgs e)
	{
		//Mensaje.IsVisible = !Mensaje.IsVisible;
		await Navigation.PushAsync(new ListaCompra(), true);
	}
}