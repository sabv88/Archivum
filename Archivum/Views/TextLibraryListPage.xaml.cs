using CommunityToolkit.Maui.Views;

namespace Archivum.Views;

public partial class TextLibraryListPage : ContentPage
{
	public TextLibraryListPage(TextLibraryListViewModel viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}

    async void HandleSimplePopupButtonClicked(object sender, EventArgs e)
    {
        var simplePopup = new TextPopup();
        await this.ShowPopupAsync(simplePopup);
    }
}