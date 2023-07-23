using CommunityToolkit.Maui.Views;

namespace Archivum.Views;

public partial class TextLibraryListPage : ContentPage
{
	public TextLibraryListPage()
	{
		InitializeComponent();
	}

    async void HandleSimplePopupButtonClicked(object sender, EventArgs e)
    {
        var simplePopup = new TextPopup();
        await this.ShowPopupAsync(simplePopup);
    }
}