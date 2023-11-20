using Archivum.Logic;
using CommunityToolkit.Maui;
using Microsoft.Maui.Hosting;
using Archivum.ViewModels;
using Archivum.Views;

namespace Archivum;
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

        builder.Services.AddSingleton<IRepository, Repository>();
        builder.Services.AddSingleton<VideoLibraryListViewModel>();
        builder.Services.AddSingleton<TextLibraryListViewModel>();

        builder.Services.AddSingleton<VideoLibraryListPage>();
        builder.Services.AddSingleton<TextLibraryListPage>();

        builder.Services.AddSingleton<VideoStatistick>();

        builder.Services.AddTransient<IViewModel, VideoLibraryViewModel>();
        builder.Services.AddTransient<VideoLibraryPage>();
        builder.Services.AddTransient<AddViewModel>();
        builder.Services.AddTransient<AddPage>();
        builder.Services.AddTransient<AnimeViewModel>();
        builder.Services.AddTransient<AnimePage>();
        builder.Services.AddTransient<FilmViewModel>();     
        builder.Services.AddTransient<FilmPage>();
        builder.Services.AddTransient<SerialViewModel>();
        builder.Services.AddTransient<SerialPage>();
        builder.Services.AddTransient<BookPage>();
        builder.Services.AddTransient<MangaPage>();
        builder.Services.AddTransient<AddPageText>();

        return builder.Build();
	}

}
