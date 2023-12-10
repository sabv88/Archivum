using Archivum.Logic;

namespace Archivum.Views;

public partial class AddPageText : ContentPage, IQueryAttributable
{
    public AddPageText()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["AddViewModelText"] != null)
        {
            BindingContext = query["AddViewModelText"] as IViewModel;
        }
    }
}