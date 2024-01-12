using Archivum.ViewModels.Video;

namespace Archivum.Views.Video;

public partial class DroppedVideoListPage : ContentPage
{
	public DroppedVideoListPage(DroppedVideoList viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}