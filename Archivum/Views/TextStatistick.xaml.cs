using Archivum.Logic;
using Archivum.ViewModels;

namespace Archivum.Views;

public partial class TextStatistick : ContentPage
{
	public TextStatistick(IRepository repository)
	{
        this.BindingContext = new TextStatistickViewModel(repository);
        InitializeComponent();
	}
}