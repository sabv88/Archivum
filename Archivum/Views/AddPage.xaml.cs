using Archivum.Logic;
using Archivum.ViewModels;

namespace Archivum.Views;

public partial class AddPage : ContentPage, IQueryAttributable
{
	public AddPage(IViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["AddViewModel"] != null)
        {
            BindingContext = query["AddViewModel"] as IViewModel;
        }
    }
}