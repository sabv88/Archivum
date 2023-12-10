using Archivum.Interfaces;
using Archivum.ViewModels;
using Archivum.ViewModels.Text;

namespace Archivum.Views;

public partial class TextStatistick : ContentPage
{
	public TextStatistick(ITextStatistickViewModel viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
	}
}