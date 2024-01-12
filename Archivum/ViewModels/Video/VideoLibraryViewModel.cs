using Archivum.Logic;
using System.Windows.Input;
using Archivum.Models;
using Archivum.Interfaces;
using CommunityToolkit.Mvvm.Messaging;
using Archivum.Models.Video;
using Archivum.Logic.Messages.Video;
using Archivum.Models.Text;

namespace Archivum.ViewModels.Video;

public partial class VideoLibraryViewModel : BaseViewModel, IViewModel
{
    internal IRepository repository;

    public ICommand SaveItem => new Command<object>(
           execute: (obj) =>
           {
               repository.SaveItemAsync(new VideoMaterial(ID, name, cover, status, estimation), ID);
           });

    public ICommand DeleteItem => new Command(
        execute: async () =>
        {
            _ = repository.DeleteItemAsync(new VideoMaterial(ID, name, cover, status, estimation));
            WeakReferenceMessenger.Default.Send(new DeleteVideoFinishedItemMessage(this));
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

    public VideoLibraryViewModel(IModel vd, IRepository repository) : base(vd)
    {
        this.repository = repository;
    }

    public VideoLibraryViewModel(int iD, byte[] cover, string name, int status, int estimation, IRepository repository) : base(iD, cover, name, status, estimation)
    {
        this.repository = repository;
    }

    public void SendMessageAdd(int status, IViewModel view)
    {
        switch (status)
        {
            case 0:
                {
                    WeakReferenceMessenger.Default.Send(new AddVideoInProgressItemMessage(view));
                    break;
                }
            case 1:
                {
                    WeakReferenceMessenger.Default.Send(new AddVideoFinishedItemMessage(view));
                    break;
                }
            case 2:
                {
                    WeakReferenceMessenger.Default.Send(new AddVideoDroppedItemMessage(view));
                    break;
                }
            case 3:
                {
                    WeakReferenceMessenger.Default.Send(new AddVideoInPlanItemMessage(view));
                    break;
                }
        }
    }
    public void SendMessageDelete(int status, IViewModel view)
    {
        switch (status)
        {
            case 0:
                {
                    WeakReferenceMessenger.Default.Send(new DeleteVideoInProgressItemMessage(view));
                    break;
                }
            case 1:
                {
                    WeakReferenceMessenger.Default.Send(new DeleteVideoFinishedItemMessage(view));
                    break;
                }
            case 2:
                {
                    WeakReferenceMessenger.Default.Send(new DeleteVideoDroppedItemMessage(view));
                    break;
                }
            case 3:
                {
                    WeakReferenceMessenger.Default.Send(new DeleteVideoInPlanItemMessage(view));
                    break;
                }
        }
    }
}

