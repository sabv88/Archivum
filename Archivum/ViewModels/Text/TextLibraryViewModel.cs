using Archivum.Logic;
using System.Windows.Input;
using Archivum.Models;
using Archivum.Interfaces;
using CommunityToolkit.Mvvm.Messaging;
using Archivum.Models.Text;

namespace Archivum.ViewModels.Text;

public class TextLibraryViewModel : BaseViewModel, IViewModel
{
    internal IRepository repository;

    public ICommand SaveItem => new Command(
    execute: () =>
    {
        repository.SaveItemAsync(new TextMaterial(ID, name, cover), ID);
        WeakReferenceMessenger.Default.Send(new AddTextItemMessage(this));

    });

    public ICommand DeleteItem => new Command(
    execute: async () =>
    {
        _ = repository.DeleteItemAsync(new TextMaterial(ID, name, cover));
        WeakReferenceMessenger.Default.Send(new DeleteTextItemMessage(this));
        await Shell.Current.GoToAsync($"..");
    });

    public ICommand AddImage => new Command(
        execute: () =>
        {
            TakePhoto();
        });

    public TextLibraryViewModel(IRepository repository)
    {
        this.repository = repository;
    }

    public TextLibraryViewModel(IModel vd, IRepository repository) : base(vd)
    {
        ID = vd.ID;
        Name = vd.Name;
        cover = vd.Cover;
        this.repository = repository;
    }

    public TextLibraryViewModel(int ID, string Name, byte[] cover, IRepository repository)
    {
        this.repository = repository;
        this.ID = ID;
        this.Name = Name;
        this.cover = cover;
    }

}
