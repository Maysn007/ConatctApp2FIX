using CommunityToolkit.Maui;
using ContactApp2.Core.ViewModels;
using ContactApp2.Data.Services;
using Microsoft.Extensions.Logging;

namespace ContactApp2.ContactManager;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<IRepository>(new Repository(""));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
