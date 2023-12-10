using Archivum.Logic;
using CommunityToolkit.Maui;
using Microsoft.Maui.Hosting;
using Archivum.Views;
using Archivum.ViewModels.Video;
using Archivum.ViewModels.Text;
using Archivum.Interfaces;
using Archivum.ViewModels.Games;
using Archivum.Views.Games;

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
        builder.Services.AddSingleton<GamesListViewModel>();
        builder.Services.AddSingleton<ITextStatistickViewModel, TextStatistickViewModel>();
        builder.Services.AddSingleton<IVideoStatistickViewModel, VideoStatictickViewModel>();
        builder.Services.AddSingleton<IGamesStatistickViewModel, GamesStatistickViewModel>();
        builder.Services.AddSingleton<IVideoStatictickService, VideoStatictickService>();
        builder.Services.AddSingleton<ITextStatictickService, TextStatistickService>();
        builder.Services.AddSingleton<IGamesStatictickService, GamesStatisticService>();

        builder.Services.AddSingleton<IlistService, ListService>();

        builder.Services.AddSingleton<VideoLibraryListPage>();
        builder.Services.AddSingleton<TextLibraryListPage>();
        builder.Services.AddSingleton<GamesLibraryListPage>();

        builder.Services.AddSingleton<TextStatistick>();
        builder.Services.AddSingleton<VideoStatistick>();
        builder.Services.AddSingleton<GamesStatistick>();

        builder.Services.AddTransient<IViewModel, VideoLibraryViewModel>();
        builder.Services.AddTransient<VideoLibraryPage>();
        builder.Services.AddTransient<TextLibraryPage>();
        builder.Services.AddTransient<AddViewModel>();
        builder.Services.AddTransient<AddPage>();
        builder.Services.AddTransient<AnimePage>();
        builder.Services.AddTransient<FilmPage>();
        builder.Services.AddTransient<SerialPage>();
        builder.Services.AddTransient<BookPage>();
        builder.Services.AddTransient<MangaPage>();
        builder.Services.AddTransient<AddPageText>();

        return builder.Build();
	}

}
