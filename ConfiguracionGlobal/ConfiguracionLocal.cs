using ConfiguracionGlobal.Modelos;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ConfiguracionGlobal
{
	// All the code in this file is included in all platforms.

	public class ConfiguracionLocal
	{
		private static readonly ConfiguracionLocal _confgiguracionLocal = new ConfiguracionLocal();

		private readonly IConfiguration _configuracion;

		private ConfiguracionLocal()
		{
			var a = Assembly.GetExecutingAssembly();
			using Stream stream = a.GetManifestResourceStream("ConfiguracionGlobal.Configuracion.json");
			{
				_configuracion = new ConfigurationBuilder()
				.AddJsonStream(stream)
				.AddEnvironmentVariables()
				.Build();
			}
		}

		//public static IConfiguration Configuracion { get => _confgiguracionLocal._configuracion; }
		public static Opciones VerOpciones() => _confgiguracionLocal._configuracion.GetRequiredSection("Opciones").Get<Opciones>();
	}
}