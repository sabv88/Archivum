using Archivum.Interfaces;

namespace Archivum.Views;

public partial class VideoStatistick : ContentPage
{
	public VideoStatistick(IVideoStatistickViewModel videoStatictickViewModel)
	{
		this.BindingContext = videoStatictickViewModel;
		InitializeComponent();
	}
}