using Archivum.Logic;

namespace Archivum.Views;

public partial class AnimePage : ContentPage, IQueryAttributable
{
    public AnimePage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["animeViewModel"] != null)
        {
            BindingContext = query["animeViewModel"] as IViewModel;
        }
    }
}