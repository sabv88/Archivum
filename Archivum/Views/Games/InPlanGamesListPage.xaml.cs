using Archivum.ViewModels.Games;

namespace Archivum.Views.Games;

public partial class InPlanGamesListPage : ContentPage
{
	public InPlanGamesListPage(InPlansGamesList viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}