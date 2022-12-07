namespace MisEstilos
{
	public static class TiposBotones
	{
		public static void BotonLargo(Button boton)
		{
			if (boton != null)
			{
				boton.WidthRequest = 400;
#if WINDOWS
#else
				boton.WidthRequest = 300;
#endif
			}
		}

		public static void BotonCorto(Button boton)
		{
			if (boton != null)
			{
				boton.WidthRequest = 300;
#if WINDOWS
#else
				boton.WidthRequest = 150;
				boton.LineBreakMode = LineBreakMode.WordWrap;
#endif
			}
		}
	}
}

