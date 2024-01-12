using Archivum.ViewModels.Video;

namespace Archivum.Views.Video;

public partial class InProgressVideoListPage : ContentPage
{
	public InProgressVideoListPage(InProgerssVideoList viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}