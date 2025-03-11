using CommunityToolkit.Maui;
using ContactApp2.ContactManager.pages;
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

		builder.Services.AddSingleton<AddPage>();
        builder.Services.AddSingleton<AddViewModel>();

        var path = FileSystem.AppDataDirectory;
		System.Diagnostics.Debug.WriteLine("Pfad: " + path);
		string file = Path.Combine(path, "contacts.xml");

		if (File.Exists(file))
		{
			System.Diagnostics.Debug.WriteLine("File exists");
        }
		else
		{
			System.Diagnostics.Debug.WriteLine("File does not exists");
        }

		builder.Services.AddSingleton<IRepository>(new Repository(file));

#if DEBUG
			builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
