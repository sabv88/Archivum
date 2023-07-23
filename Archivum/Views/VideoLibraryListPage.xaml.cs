using Archivum;
using CommunityToolkit.Maui.Views;

namespace Archivum.Views;

public partial class VideoLibraryListPage : ContentPage
{
    public VideoLibraryListPage()
	{ 
        InitializeComponent();          
    }

    async void HandleSimplePopupButtonClicked(object sender, EventArgs e)
    {
        await PopupButton.FadeTo(0, 150);
        await PopupButton.FadeTo(1, 150);
        var simplePopup = new VideoPopup();
        await this.ShowPopupAsync(simplePopup);
    }
}   