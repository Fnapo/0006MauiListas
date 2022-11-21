using CompraSemanal.Vistas;

namespace CompraSemanal;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//Routing.RegisterRoute(nameof(CrearCadena), typeof(CrearCadena));
		//Routing.RegisterRoute(nameof(ErrorConexion), typeof(ErrorConexion));
	}
}
