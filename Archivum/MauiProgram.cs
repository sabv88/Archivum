using Archivum.Logic;
using CommunityToolkit.Maui;
using Archivum.Views;
using Archivum.ViewModels.Video;
using Archivum.ViewModels.Text;
using Archivum.ViewModels.Games;
using Archivum.Interfaces;
using Archivum.Views.Games;
using Archivum.Views.Video;
using Archivum.Views.Text;
using Microcharts.Maui;

namespace Archivum;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMicrocharts()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Gothirus.ttf", "Gothirus");
                fonts.AddFont("MastodonBold.ttf", "Mastodon");
                fonts.AddFont("FundamentalBrigadeSchwer.ttf", "Fundamental");
                fonts.AddFont("manga.ttf", "manga");
                fonts.AddFont("anime.ttf", "anime");
                fonts.AddFont("games.ttf", "games");
                fonts.AddFont("film.ttf", "film");
                fonts.AddFont("serial.ttf", "serial");
            });

        builder.Services.AddSingleton<IRepository, Repository>();

        builder.Services.AddSingleton<VideoLibraryListViewModel>();
        builder.Services.AddSingleton<DroppedVideoList>();
        builder.Services.AddSingleton<InProgerssVideoList>();
        builder.Services.AddSingleton<InPlanVideoList>();
        builder.Services.AddSingleton<FinishedVideoList>();
        builder.Services.AddSingleton<TextLibraryListViewModel>();
        builder.Services.AddSingleton<DroppedTextList>();
        builder.Services.AddSingleton<InProgressTextList>();
        builder.Services.AddSingleton<InPlanTextList>();
        builder.Services.AddSingleton<FinishedTextList>();
        builder.Services.AddSingleton<GamesListViewModel>();
        builder.Services.AddSingleton<DroppedGamesList>();
        builder.Services.AddSingleton<InProgressGamesList>();
        builder.Services.AddSingleton<InPlansGamesList>();
        builder.Services.AddSingleton<FinishedGamesList>();

        builder.Services.AddSingleton<ITextStatistickViewModel, TextStatistickViewModel>();
        builder.Services.AddSingleton<IVideoStatistickViewModel, VideoStatictickViewModel>();
        builder.Services.AddSingleton<IGamesStatistickViewModel, GamesStatistickViewModel>();
        builder.Services.AddSingleton<IVideoStatictickService, VideoStatictickService>();
        builder.Services.AddSingleton<ITextStatictickService, TextStatistickService>();
        builder.Services.AddSingleton<IGamesStatictickService, GamesStatisticService>();

        builder.Services.AddSingleton<IlistService, ListService>();

        builder.Services.AddSingleton<VideoLibraryListPage>();
        builder.Services.AddSingleton<DroppedVideoListPage>();
        builder.Services.AddSingleton<InProgressVideoListPage>();
        builder.Services.AddSingleton<InPlanVideoListPage>();
        builder.Services.AddSingleton<TextLibraryListPage>();
        builder.Services.AddSingleton<DroppedTextLibraryListPage>();
        builder.Services.AddSingleton<InProgressTextLibraryListPage>();
        builder.Services.AddSingleton<InPlanTextLibraryListPage>();
        builder.Services.AddSingleton<GamesLibraryListPage>();
        builder.Services.AddSingleton<DroppedGamesListPage>();
        builder.Services.AddSingleton<InProgressGamesListPage>();
        builder.Services.AddSingleton<InPlanGamesListPage>();

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
