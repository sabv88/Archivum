using Archivum.ViewModels.Text;
using CommunityToolkit.Maui.Views;

namespace Archivum.Views;

public partial class TextLibraryListPage : ContentPage
{
	public TextLibraryListPage(FinishedTextList viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}