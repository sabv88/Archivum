using Archivum.ViewModels.Games;

namespace Archivum.Views;

public partial class GamesLibraryListPage : ContentPage
{
	public GamesLibraryListPage(GamesListViewModel viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
    }
}