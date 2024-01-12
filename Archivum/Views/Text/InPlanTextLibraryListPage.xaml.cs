using Archivum.ViewModels.Text;

namespace Archivum.Views.Text;

public partial class InPlanTextLibraryListPage : ContentPage
{
	public InPlanTextLibraryListPage(InPlanTextList viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}