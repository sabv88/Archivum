using Archivum.ViewModels.Video;

namespace Archivum.Views.Video;

public partial class InPlanVideoListPage : ContentPage
{
	public InPlanVideoListPage(InPlanVideoList viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}