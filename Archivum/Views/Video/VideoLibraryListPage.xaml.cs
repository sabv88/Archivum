using Archivum.ViewModels.Video;
namespace Archivum.Views;

public partial class VideoLibraryListPage : ContentPage
{
    public VideoLibraryListPage(FinishedVideoList viewModel)
	{ 
        this.BindingContext = viewModel;
        InitializeComponent();          
    }
}  