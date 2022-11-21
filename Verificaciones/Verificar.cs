namespace Verificaciones
{
	// All the code in this file is included in all platforms.
	public static class Verificar
	{
		public static int EnteroMinimo { get; } = (int)-1e9;
		public static int EnteroMaximo { get; } = (int)1e9;

		public static void VerificarObligatorio(Entry entrada, Label etiqueta, Style entradaValida, Style entradaFalsa)
		{
			string texto = entrada.Text.Trim();
			bool correcto = (texto.Length != 0);

			entrada.Style = correcto ? entradaValida : entradaFalsa;
			etiqueta.Text = "Campo Obligatorio";
			etiqueta.IsVisible = !correcto;
		}

		public static void VerificarEspaciosInternos(Entry entrada, Label etiqueta, Style entradaValida, Style entradaFalsa)
		{
			string texto = entrada.Text.Trim();
			bool correcto = !texto.Contains(' ');

			entrada.Style = correcto ? entradaValida : entradaFalsa;
			etiqueta.Text = "Campo sin Espacios";
			etiqueta.IsVisible = !correcto;
		}

		public static void VerificarEntero(Entry entrada, Label etiqueta, Style entradaValida, Style entradaFalsa,
			int minimo, int maximo)
		{
			bool correcto;
			int valor;

			try
			{
				valor = int.Parse(entrada.Text);
			}
			catch (Exception)
			{
				entrada.Style = entradaFalsa;
				etiqueta.Text = "El Campo debe ser un Entero";
				etiqueta.IsVisible = true;

				return;
			}

			correcto = (valor >= minimo && valor <= maximo);
			entrada.Style = (correcto ? entradaValida : entradaFalsa);
			etiqueta.Text = $"El Valor debe estar entre {minimo} y {maximo}";
			etiqueta.IsVisible = !correcto;
		}
	}
}