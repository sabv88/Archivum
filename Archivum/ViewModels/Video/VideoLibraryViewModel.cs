using Archivum.Logic;
using System.Windows.Input;
using Archivum.Models;
using Archivum.ViewModels;
using Archivum.Interfaces;
using CommunityToolkit.Mvvm.Messaging;
using Archivum.Models.Video;

namespace Archivum.ViewModels.Video;

public partial class VideoLibraryViewModel : BaseViewModel, IViewModel
{
    internal IRepository repository;

    public ICommand SaveItem => new Command<object>(
           execute: (obj) =>
           {
               repository.SaveItemAsync(new VideoMaterial(ID, name, cover), ID);
           });

    public ICommand DeleteItem => new Command(
        execute: async () =>
        {
            _ = repository.DeleteItemAsync(new Material(ID, name, cover));
            WeakReferenceMessenger.Default.Send(new DeleteVideoItemMessage(this));
            await Shell.Current.GoToAsync($"..");
        });

    public ICommand AddImage => new Command(
        execute: () =>
        {
            TakePhoto();
        });

    public VideoLibraryViewModel(IRepository repository)
    {
        this.repository = repository;
    }

    public VideoLibraryViewModel(IModel vd, IRepository repository)
    {
        this.repository = repository;
        ID = vd.ID;
        Name = vd.Name;
        cover = vd.Cover;
    }

    public VideoLibraryViewModel(int ID, string Name, byte[] cover, IRepository repository)
    {
        this.repository = repository;
        this.ID = ID;
        this.Name = Name;
        this.cover = cover;
    }
}

