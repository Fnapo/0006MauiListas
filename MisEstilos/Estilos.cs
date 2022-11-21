namespace MisEstilos
{
	// All the code in this file is included in all platforms.
	public static class Estilos
	{
		private static readonly ResourceDictionary listaEstilos = Application.Current.Resources.MergedDictionaries.ToArray()[2];
		public static Style EntradaValida { get; } = listaEstilos["EstiloEntryOK"] as Style;
		public static Style EntradaFalsa { get; } = listaEstilos["EstiloEntryNoOK"] as Style;
		public static Style AvisoError { get; } = listaEstilos["EstiloLabelAvisoError"] as Style;
		public static Style AvisoOK { get; } = listaEstilos["EstiloLabelAvisoOK"] as Style;
		public static Style BotonActivo { get; } = listaEstilos["EstiloBotonActivo"] as Style;
		public static Style BotonNoActivo { get; } = listaEstilos["EstiloBotonNoActivo"] as Style;
		public static Style BotonAvanzar { get; } = listaEstilos["EstiloBotonAvanzar"] as Style;
		public static Style BotonPeligro { get; } = listaEstilos["EstiloBotonPeligro"] as Style;
	}
}