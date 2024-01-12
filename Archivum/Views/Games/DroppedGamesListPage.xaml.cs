using Archivum.ViewModels.Games;

namespace Archivum.Views.Games;

public partial class DroppedGamesListPage : ContentPage
{
	public DroppedGamesListPage(DroppedGamesList viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}