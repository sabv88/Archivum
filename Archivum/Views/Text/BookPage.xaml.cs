using Archivum.Logic;

namespace Archivum.Views;

public partial class BookPage : ContentPage, IQueryAttributable
{
    public BookPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["bookViewModel"] != null)
        {
            BindingContext = query["bookViewModel"] as IViewModel;
        }
    }
}