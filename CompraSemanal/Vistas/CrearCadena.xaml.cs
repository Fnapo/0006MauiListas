
using ClasesMysql;
using CommunityToolkit.Maui.Behaviors;
using ConfiguracionGlobal;
using ConfiguracionGlobal.Modelos;
using MisEstilos;
using Verificaciones;

namespace CompraSemanal.Vistas;

public partial class CrearCadena : ContentPage
{
	/*
	private static readonly string _claveServidor = "Servidor", _clavePuerto = "Puerto", _claveUsuario = "Usuario",
		_clavePassword = "Password", _claveBaseDatos = "BaseDatos";
	*/

	//private bool _probado;
	//private static Style entradaValida, entradaFalsa;

	public CrearCadena()
	{
		InitializeComponent();

		PrepararBotones();
		//CrearConfiguracion();
		//LeerConfiguracion();
		OcultarErrores();
		EstablecerValores();
		//_probado = false;
		//AsignarEstilos();
		CrearBehaviors();
		CicloEntradas();
	}

	private void PrepararBotones()
	{
		EstilosBotones.BotonLargo(xBotonProbar);
	}

	private void OcultarErrores()
	{
		xErrorServidor.IsVisible = xErrorPuerto.IsVisible = xErrorUsuario.IsVisible
			= xErrorPass.IsVisible = xErrorBase.IsVisible = false;
	}

	private void EstablecerValores()
	{
		/*IConfiguration configuracion = new ConfigurationBuilder()
			.AddJsonFile("Configuracion.json")
			.AddEnvironmentVariables()
			.Build();
		*/
		Opciones opciones = ConfiguracionLocal.VerOpciones();

		/*
		xServidor.Text = Preferences.Get(_claveServidor, "");
		xPuerto.Text = Preferences.Get(_clavePuerto, "");
		xUsuario.Text = Preferences.Get(_claveUsuario, "");
		xPass.Text = Preferences.Get(_clavePassword, "");
		xBaseDatos.Text = Preferences.Get(_claveBaseDatos, "");
		*/

		xServidor.Text = opciones.Servidor;
		xPuerto.Text = opciones.Puerto;
		xUsuario.Text = opciones.Usuario;
		xPass.Text = opciones.Password;
		xBaseDatos.Text = opciones.BaseDatos;
	}
	/*
	private static void AsignarEstilos()
	{
		var listaEstilos = Application.Current.Resources.MergedDictionaries.ToArray()[2];

		//entradaValida = listaEstilos["EstiloEntryOK"] as Style;
		//entradaFalsa = listaEstilos["EstiloEntryNoOK"] as Style;
	}
	*/

	private void CicloEntradas()
	{
		SetFocusOnEntryCompletedBehavior.SetNextElement(xServidor, xPuerto);
		SetFocusOnEntryCompletedBehavior.SetNextElement(xPuerto, xUsuario);
		SetFocusOnEntryCompletedBehavior.SetNextElement(xUsuario, xPass);
		SetFocusOnEntryCompletedBehavior.SetNextElement(xPass, xBaseDatos);
		SetFocusOnEntryCompletedBehavior.SetNextElement(xBaseDatos, xServidor);
	}

	private void CrearBehaviors()
	{
		/*
		var noEspacios = new CharactersValidationBehavior
		{
			InvalidStyle = entradaFalsa,
			ValidStyle = entradaValida,
			Flags = ValidationFlags.ValidateOnValueChanged,
			CharacterType = CharacterType.Whitespace,
			MaximumCharacterTypeCount = 0
		};
		*/

		BehaviorsEntry(xServidor, VerificarServidor);
		BehaviorsEntry(xPuerto, VerificarPuerto);
		BehaviorsEntry(xUsuario, VerificarUsuario);
		BehaviorsEntry(xPass, VerificarPassword);
		BehaviorsEntry(xBaseDatos, VerificarBaseDatos);
	}

	private static void BehaviorsEntry(Entry entrada, Action accion)
	{
		var cambiaTextoEntry = new EventToCommandBehavior
		{
			EventName = nameof(Entry.TextChanged),
			Command = new Command(accion)
		};

		entrada.Behaviors.Add(cambiaTextoEntry);
	}

	private void HabilitarBotones()
	{
		bool valido= VerificacionGlobal();

		xBotonProbar.IsEnabled = valido;
		xBotonProbar.Style = (valido ? Estilos.BotonActivo : Estilos.BotonNoActivo);
	}

	private bool VerificacionGlobal()
	{
		bool salida = (!xErrorServidor.IsVisible && !xErrorPuerto.IsVisible && !xErrorUsuario.IsVisible
			&& !xErrorPass.IsVisible && !xErrorBase.IsVisible);

		return salida;
	}

	private void VerificarServidor()
	{
		Verificar.VerificarObligatorio(xServidor, xErrorServidor, Estilos.EntradaValida, Estilos.EntradaFalsa);
		if (!xErrorServidor.IsVisible)
		{
			Verificar.VerificarEspaciosInternos(xServidor, xErrorServidor, Estilos.EntradaValida, Estilos.EntradaFalsa);
		}
		HabilitarBotones();
	}

	private void VerificarPuerto()
	{
		Verificar.VerificarEntero(xPuerto, xErrorPuerto, Estilos.EntradaValida, Estilos.EntradaFalsa, 1000, 4000);
		HabilitarBotones();
	}

	private void VerificarUsuario()
	{
		Verificar.VerificarObligatorio(xUsuario, xErrorUsuario, Estilos.EntradaValida, Estilos.EntradaFalsa);
		if (!xErrorUsuario.IsVisible)
		{
			Verificar.VerificarEspaciosInternos(xUsuario, xErrorUsuario, Estilos.EntradaValida, Estilos.EntradaFalsa);
		}
		HabilitarBotones();
	}

	private void VerificarPassword()
	{
		Verificar.VerificarObligatorio(xPass, xErrorPass, Estilos.EntradaValida, Estilos.EntradaFalsa);
		if (!xErrorPass.IsVisible)
		{
			Verificar.VerificarEspaciosInternos(xPass, xErrorPass, Estilos.EntradaValida, Estilos.EntradaFalsa);
		}
		HabilitarBotones();
	}

	private void VerificarBaseDatos()
	{
		Verificar.VerificarObligatorio(xBaseDatos, xErrorBase, Estilos.EntradaValida, Estilos.EntradaFalsa);
		if (!xErrorBase.IsVisible)
		{
			Verificar.VerificarEspaciosInternos(xBaseDatos, xErrorBase, Estilos.EntradaValida, Estilos.EntradaFalsa);
		}
		HabilitarBotones();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		xServidor.Focus();
	}

	private async void ProbarClick(object sender, EventArgs e)
	{
		//_probado = true;
		await Navigation.PushAsync(new Probando(CadenaMysql()), true);
	}

	private string CadenaMysql()
	{
		string salida = ConexionMysql.CrearCadenaConexion(xServidor.Text, xPuerto.Text, xUsuario.Text, xPass.Text, xBaseDatos.Text);

		return salida;
	}

	/*
	private static void LeerConfiguracion()
	{
		Preferences.Default.Set(_claveServidor, "paco2015.ddns.net");
		Preferences.Default.Set(_clavePuerto, "3308");
		Preferences.Default.Set(_claveUsuario, "administrador$");
		Preferences.Default.Set(_clavePassword, "fesopo1808$0");
		Preferences.Default.Set(_claveBaseDatos, "pryca");
	}
	*/

	protected override bool OnBackButtonPressed()
	{
		return true;
	}
}