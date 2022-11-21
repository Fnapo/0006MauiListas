
using ClasesMysql;

namespace CompraSemanal.Vistas;

//[QueryProperty(nameof(MensajeError), "error")]
public partial class ErrorConexion : ContentPage
{
	public ErrorConexion()
	{
		InitializeComponent();

		//Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false, IsEnabled=false });
		labelError.Text = ConexionMysql.MensajeError;
	}

	private void BotonSalirPulsado(object sender, EventArgs e)
	{
		Environment.Exit(1);
		//System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
	}
	/*
	protected override bool OnBackButtonPressed()
	{
		return true;
	}

	private void BotonVolverPulsado(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync($"{nameof(CrearCadena)}");
	}
	*/
}