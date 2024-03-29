using Archivum.Logic;
using Archivum.ViewModels;

namespace Archivum.Views;

public partial class SerialPage : ContentPage, IQueryAttributable
{

    public SerialPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["serialViewModel"] != null)
        {
            BindingContext = query["serialViewModel"] as IViewModel;
        }

    }
}