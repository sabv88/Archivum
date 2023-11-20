using Archivum.Logic;

namespace Archivum.Views;

public partial class MangaPage : ContentPage, IQueryAttributable
{
    public MangaPage(IViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["mangaViewModel"] != null)
        {
            BindingContext = query["mangaViewModel"] as IViewModel;
        }
    }
}