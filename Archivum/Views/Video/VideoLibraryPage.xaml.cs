

using Archivum.Logic;

namespace Archivum
{
    public partial class VideoLibraryPage : ContentPage, IQueryAttributable
    {
        public VideoLibraryPage(IViewModel viewModel)
        {
            BindingContext = viewModel;

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