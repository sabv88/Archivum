using CommunityToolkit.Maui.Views;

namespace Archivum.Views;

public partial class VideoPopup : Popup
{
	public VideoPopup()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await AddButton.FadeTo(0, 150);
        await AddButton.FadeTo(1, 150);
        this.Close();
    }

    private async void StatistickButton_Clicked(object sender, EventArgs e)
    {
        await StatistickButton.FadeTo(0, 150);
        await StatistickButton.FadeTo(1, 150);
        this.Close();
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.Close();
    }
}