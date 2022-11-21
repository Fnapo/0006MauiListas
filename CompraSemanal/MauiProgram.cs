using CompraSemanal.Vistas;
using CommunityToolkit.Maui;
using Microsoft.Maui.Handlers;

namespace CompraSemanal;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        builder.Services.AddTransient<Probando>();

		EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
		{
			if (view is Entry)
			{
#if ANDROID
				handler.PlatformView.SetPadding(10, 0, 0, 0);
#endif
			}
		});

		return builder.Build();
    }
}