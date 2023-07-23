using Archivum.ViewModels;
using Archivum.Views;

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
        Routes.Add("textlibraryListPage", typeof(TextLibraryListPage));
        Routes.Add("textlibraryPage", typeof(TextLibraryPage));
        Routes.Add("videoStatictickPage", typeof(VideoStatistick));
        Routes.Add("textStatictickPage", typeof(TextStatistick));

        foreach (var item in Routes)
        {
            Routing.RegisterRoute(item.Key, item.Value);
        }
    }
}
