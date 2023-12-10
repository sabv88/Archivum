using Archivum.Interfaces;

namespace Archivum.Views.Games;

public partial class GamesStatistick : ContentPage
{
    public GamesStatistick(IGamesStatistickViewModel viewModel)
    {
        this.BindingContext = viewModel;
        InitializeComponent();
    }
}