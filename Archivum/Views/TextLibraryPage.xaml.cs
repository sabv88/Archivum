namespace Archivum
{
	public partial class TextLibraryPage : ContentPage
	{
		public TextLibraryPage(TextLibraryViewModel viewModel)
		{
			this.BindingContext = viewModel;
			InitializeComponent();
		}
	}
}

