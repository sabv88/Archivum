using Archivum.ViewModels.Text;

namespace Archivum.Views.Text;

public partial class DroppedTextLibraryListPage : ContentPage
{
	public DroppedTextLibraryListPage(DroppedTextList viewModel)
    {
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}