
using ClasesMysql;
using MisEstilos;

namespace CompraSemanal.Vistas;

public partial class Probando : ContentPage
{
	private readonly string _cadena;

	public Probando(string cadena)
	{
		InitializeComponent();

		_cadena = cadena;
		Preparacion();
		ProbarConexion();
		//PreparaciosPost();
	}

	private void Preparacion()
	{
		Mensaje.IsVisible = false;
		Indicador.IsRunning = true;
	}

	private async void Volver(object sender, EventArgs e)
	{
		await Navigation.PopAsync(true);
	}

	private void Salir(object sender, EventArgs e)
	{
		Environment.Exit(1);
	}

	private async void ProbarConexion()
	{
		//Exception e;

		await Task.Run(() => ConexionMysql.CrearConexion(_cadena));
		PreparaciosPost();
	}

	private void PreparaciosPost()
	{
		Indicador.IsRunning = false;
		Mensaje.Style = (ConexionMysql.Conexion == null ? Estilos.AvisoError : Estilos.AvisoOK);
		Mensaje.Text = ConexionMysql.MensajeError;
		Mensaje.IsVisible = true;
		BotonVolver.IsEnabled = true;
		BotonSalir.IsEnabled = true;
		BotonLeer.IsEnabled = (ConexionMysql.Conexion != null);
		BotonSalir.Style = Estilos.BotonPeligro;
		BotonVolver.Style = Estilos.BotonActivo;
		BotonLeer.Style = (BotonLeer.IsEnabled ? Estilos.BotonAvanzar : Estilos.BotonNoActivo);
	}

	/*
	private void Probar(object sender, EventArgs e)
	{	
		BotonProbar.IsVisible = false;
		Indicador.IsVisible = true;
		ConexionMysql.CrearConexion(_cadena);
		Indicador.IsVisible = false;
		Mensaje.TextColor = (ConexionMysql.Conexion == null ? Color.FromArgb("#ff0000") : Color.FromArgb("#008000"));
		Mensaje.Text = ConexionMysql.MensajeError;
		Mensaje.IsVisible = true;
		BotonVolver.IsEnabled = true;
		BotonSalir.IsEnabled = (ConexionMysql.Conexion == null);		
	}
*/

	private async void LecturaDatos(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LeerDatos(), true);
	}

	protected override bool OnBackButtonPressed()
	{
		return true;
	}
}