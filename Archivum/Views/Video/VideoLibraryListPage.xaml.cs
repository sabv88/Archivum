using Archivum.ViewModels.Video;
using CommunityToolkit.Maui.Views;

namespace Archivum.Views;

public partial class VideoLibraryListPage : ContentPage
{
    public VideoLibraryListPage(VideoLibraryListViewModel viewModel)
	{ 
        this.BindingContext = viewModel;
        InitializeComponent();          
    }
}  