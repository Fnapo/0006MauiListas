
using ClasesMysql;
using ClasesPryca.Modelos;
using ClasesPryca.Modelos.Static;
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

	public static List<Oferta> Ofertas { get; private set; } = new List<Oferta>();
	public static List<Producto> Productos { get; private set; } = new List<Producto>();

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

	private void BotonesFinal()
	{
		AvisosLectura lecturaCorecta = LecturaCorrecta();

		BotonSalir.IsEnabled = true;
		BotonSalir.Style = Estilos.BotonPeligro;
		BotonCrear.Style = (lecturaCorecta==AvisosLectura.LecturaCorrecta ? Estilos.BotonAvanzar : Estilos.BotonNoActivo);
		Mensaje.Text = (lecturaCorecta == AvisosLectura.LecturaCorrecta ? "Lectura Correcta ..." : "Error en la tabla de "
			+ (lecturaCorecta == AvisosLectura.ErrorEnOfertas ? "Ofertas ..." : "Productos ..."));
		Mensaje.IsVisible = true;
	}

	private void Salir(object sender, EventArgs e)
	{
		Environment.Exit(1);
	}

	private async void LeerDatosArticulos()
	{
		Ofertas = await Task.Run(() => DBPryca.Contexto.Oferta.Where(o => o.Idoferta == 1).ToList());
		BotonesFinal();
	}

	private AvisosLectura LecturaCorrecta()
	{
		bool correcta = Ofertas.Count > 0;

		if(!correcta)
		{
			return AvisosLectura.ErrorEnOfertas;
		}
		/*
		correcta = Productos.Count > 0;
		if(!correcta)
		{
			return correcta;
		}
		*/

		return AvisosLectura.LecturaCorrecta;
	}

	protected override bool OnBackButtonPressed()
	{
		return true;
	}

	private void CrearLista(object sender, EventArgs e)
	{

	}
}