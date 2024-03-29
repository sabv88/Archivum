﻿using Archivum.ViewModels;
using Archivum.Views;
using Archivum.Views.Games;
using Archivum.Views.Video;

namespace Archivum;

public partial class AppShell : Shell
{
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
    public AppShell()
	{
		InitializeComponent();
        RegisterRoutes();
        BindingContext = this;

    }
    void RegisterRoutes()
    {
        Routes.Add("videolibraryPage", typeof(VideoLibraryPage));
        Routes.Add("videolibraryListPage", typeof(VideoLibraryListPage));
        Routes.Add("gameslibraryListPage", typeof(GamesLibraryListPage));
        Routes.Add("droppedVideoListPage", typeof(DroppedVideoListPage));
        Routes.Add("textlibraryListPage", typeof(TextLibraryListPage));
        Routes.Add("textlibraryPage", typeof(TextLibraryPage));
        Routes.Add("gamesLibraryPage", typeof(GamePage));
        Routes.Add("videoStatictickPage", typeof(VideoStatistick));
        Routes.Add("textStatictickPage", typeof(TextStatistick));
        Routes.Add("gamesStatictickPage", typeof(GamesStatistick));
        Routes.Add("serialPage", typeof(SerialPage));
        Routes.Add("animePage", typeof(AnimePage));
        Routes.Add("filmPage", typeof(FilmPage));
        Routes.Add("addPage", typeof(AddPage));
        Routes.Add("bookPage", typeof(BookPage));
        Routes.Add("mangaPage", typeof(MangaPage));
        Routes.Add("addPageText", typeof(AddPageText));
        Routes.Add("addPageGames", typeof(AddPageGames));


        foreach (var item in Routes)
        {
            Routing.RegisterRoute(item.Key, item.Value);
        }
    }
}
