using Archivum.ViewModels.Games;

namespace Archivum.Views;

public partial class GamesLibraryListPage : ContentPage
{
	public GamesLibraryListPage(FinishedGamesList viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
    }
}