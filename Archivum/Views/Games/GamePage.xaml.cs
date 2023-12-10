using Archivum.Logic;

namespace Archivum.Views.Games;

public partial class GamePage : ContentPage, IQueryAttributable
{
	public GamePage()
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