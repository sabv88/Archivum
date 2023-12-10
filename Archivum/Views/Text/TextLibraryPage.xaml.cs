using Archivum.Logic;

namespace Archivum
{
    public partial class TextLibraryPage : ContentPage, IQueryAttributable
    {
		public TextLibraryPage()
		{
			InitializeComponent();
		}

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query["ViewModel"] != null)
            {
                BindingContext = query["ViewModel"] as IViewModel;
            }
        }
    }
}

