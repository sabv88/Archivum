using Archivum.Logic;
using Archivum.ViewModels;

namespace Archivum.Views;

public partial class VideoStatistick : ContentPage
{
	public VideoStatistick(IRepository repository)
	{
		this.BindingContext = new VideoStatictickViewModel(repository);
		InitializeComponent();
	}
}