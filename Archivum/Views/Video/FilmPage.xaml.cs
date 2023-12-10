using Archivum.Logic;

namespace Archivum.Views;

public partial class FilmPage : ContentPage, IQueryAttributable
{
	public FilmPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["filmViewModel"] != null)
        {
            BindingContext = query["filmViewModel"] as IViewModel;
        }

    }
}