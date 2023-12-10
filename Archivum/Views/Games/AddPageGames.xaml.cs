using Archivum.Logic;

namespace Archivum.Views.Games;

public partial class AddPageGames : ContentPage, IQueryAttributable
{
	public AddPageGames()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["AddViewModelGames"] != null)
        {
            BindingContext = query["AddViewModelGames"] as IViewModel;
        }
    }
}