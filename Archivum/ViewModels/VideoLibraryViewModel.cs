using Archivum.Logic;
using System.Windows.Input;
using Archivum.Models;
using Archivum.ViewModels;

namespace Archivum;

public partial class VideoLibraryViewModel : BaseViewModel, IViewModel
{
    internal IRepository repository;
    public int ID { get; set; }
    string name;
    public byte[] cover { get; set; } = new byte[0];

    public string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }


    public ImageSource Cover
    {
        get
        {
            if (cover.Length == 0)
            {
                return ImageSource.FromFile("picture1.svg");
            }

            MemoryStream ms = new MemoryStream(cover);
            return ImageSource.FromStream(() => ms);
        }
    }

    public ICommand SaveItem => new Command<object>(
           execute: (object obj) =>
           {
               repository.SaveItemAsync(new Material(ID, name, cover), ID);
               MessagingCenter.Send<VideoLibraryViewModel>(this, "Change video element");
               RefreshProperties();
           });

    public ICommand DeleteItem => new Command(
        execute: async () =>
        {
            _ = repository.DeleteItemAsync(new Material(ID, name, cover));
            MessagingCenter.Send<VideoLibraryViewModel>(this, "Remove video element");
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

    public VideoLibraryViewModel(Material vd, IRepository repository)
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

    public async virtual void TakePhoto()
    {
        Stream stream = await new PhotoPickerService().GetImageStreamAsync();
        if (stream != null)
        {
            MemoryStream memory = new MemoryStream();
            await stream.CopyToAsync(memory);
            cover = memory.ToArray();
            RefreshProperties();
        }
    }

    public virtual void RefreshProperties()
    {
        OnPropertyChanged("Name");
        OnPropertyChanged("Comment");
        OnPropertyChanged("Type");
        OnPropertyChanged("Cover");
    }
}

