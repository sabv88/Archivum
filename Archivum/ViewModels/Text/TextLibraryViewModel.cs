using Archivum.Logic;
using System.Windows.Input;
using Archivum.Models;
using Archivum.Interfaces;
using CommunityToolkit.Mvvm.Messaging;
using Archivum.Models.Text;
using Archivum.Logic.Messages.Text;

namespace Archivum.ViewModels.Text;

public class TextLibraryViewModel : BaseViewModel, IViewModel
{
    internal IRepository repository;
    public ICommand SaveItem => new Command(
    execute: () =>
    {
        repository.SaveItemAsync(new TextMaterial(ID, name, cover, status, estimation), ID);
        WeakReferenceMessenger.Default.Send(new AddTextFinishedItemMessage(this));

    });

    public ICommand DeleteItem => new Command(
    execute: async () =>
    {
        _ = repository.DeleteItemAsync(new TextMaterial(ID, name, cover, status, estimation));
        WeakReferenceMessenger.Default.Send(new DeleteTextInProgressItemMessage(this));
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
        this.estimation = vd.Estimation;
        this.status = vd.Status;
    }

    public TextLibraryViewModel(int ID, string Name, byte[] cover, int status, int estimation, IRepository repository)
    {
        this.repository = repository;
        this.ID = ID;
        this.Name = Name;
        this.cover = cover;
        this.status = status;
        this.estimation = estimation;
    }

    public void SendMessageAdd(int status, IViewModel view)
    {
        switch (status)
        {
            case 0:
                {
                    WeakReferenceMessenger.Default.Send(new AddTextInProgressItemMessage(view));
                    break;
                }
            case 1:
                {
                    WeakReferenceMessenger.Default.Send(new AddTextFinishedItemMessage(view));
                    break;
                }
            case 2:
                {
                    WeakReferenceMessenger.Default.Send(new AddTextDroppedItemMessage(view));
                    break;
                }
            case 3:
                {
                    WeakReferenceMessenger.Default.Send(new AddTextInPlanItemMessage(view));
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
                    WeakReferenceMessenger.Default.Send(new DeleteTextInProgressItemMessage(view));
                    break;
                }
            case 1:
                {
                    WeakReferenceMessenger.Default.Send(new DeleteTextFinishedItemMessage(view));
                    break;
                }
            case 2:
                {
                    WeakReferenceMessenger.Default.Send(new DeleteTextDroppedItemMessage(view));
                    break;
                }
            case 3:
                {
                    WeakReferenceMessenger.Default.Send(new DeleteTextInPlanItemMessage(view));
                    break;
                }
        }
    }

}
