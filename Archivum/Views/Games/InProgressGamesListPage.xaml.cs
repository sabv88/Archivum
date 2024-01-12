using Archivum.ViewModels.Games;

namespace Archivum.Views.Games;

public partial class InProgressGamesListPage : ContentPage
{
	public InProgressGamesListPage(InProgressGamesList viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}