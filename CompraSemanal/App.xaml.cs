using CompraSemanal.Vistas;

namespace CompraSemanal;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new CrearCadena());
	}
}
