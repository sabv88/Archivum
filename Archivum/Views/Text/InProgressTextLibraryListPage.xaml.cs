using Archivum.ViewModels.Text;

namespace Archivum.Views.Text;

public partial class InProgressTextLibraryListPage : ContentPage
{
	public InProgressTextLibraryListPage(InProgressTextList viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}