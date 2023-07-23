using Archivum.Logic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Archivum;

public class VideoLibraryViewModel : ObservableObject, IQueryAttributable
{
    readonly VideoLibraryRepository database = new VideoLibraryRepository();
    public VideoMaterial videoMaterial = new VideoMaterial();

    public ICommand SaveItem { get; private set; }
    public ICommand DeleteItem { get; private set; }
    public ICommand AddImage { get; private set; }

    public VideoLibraryViewModel(VideoMaterial vd)
    {
        videoMaterial = vd;
        SaveItem = new Command(
        execute: () =>
        {
            _ = database.SaveItemAsync(videoMaterial);
            MessagingCenter.Send<VideoLibraryViewModel>(this, "Change video element");
        });
        DeleteItem = new Command(
        execute: async () =>
        {
            _ = database.DeleteItemAsync(videoMaterial);
            MessagingCenter.Send<VideoLibraryViewModel>(this, "Remove video element");
            await Shell.Current.GoToAsync($"..");
        });
        AddImage = new Command(
        execute: () =>
        {
            TakePhoto();
        });
    }
    public VideoLibraryViewModel()
    {
        SaveItem = new Command(
        execute: () =>
        {
            _ = database.SaveItemAsync(videoMaterial);
            MessagingCenter.Send<VideoLibraryViewModel>(this, "Change video element");
        });
        DeleteItem = new Command(
        execute: async () =>
        {
            _ = database.DeleteItemAsync(videoMaterial);
            MessagingCenter.Send<VideoLibraryViewModel>(this, "Remove video element");
            await Shell.Current.GoToAsync($"..");
        });
        AddImage = new Command(
        execute: () =>
        {
            TakePhoto();
        });
    }
    public string Name
    {
        get => videoMaterial.Name;
        set
        {
            if (videoMaterial.Name != value)
            {
                videoMaterial.Name = value;
                OnPropertyChanged();
            }
        }
    }

    public string Type
    {
        get => videoMaterial.Type;
        set
        {
            if (videoMaterial.Type != value)
            {
                videoMaterial.Type = value;
                OnPropertyChanged();
            }
        }
    }

    public string Comment
    {
        get => videoMaterial.Comment;
        set
        {
            if (videoMaterial.Comment != value)
            {
                videoMaterial.Comment = value;
                OnPropertyChanged();
            }
        }
    }

    public ImageSource Cover
    {
        get
        {
            if (videoMaterial.Cover.Length == 0)
            {
                return ImageSource.FromFile("picture1.svg");
            }

            MemoryStream ms = new MemoryStream(videoMaterial.Cover);
            return ImageSource.FromStream(() => ms);
        }
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["videoMaterial"] != null)
        {
            videoMaterial = query["videoMaterial"] as VideoMaterial;
            RefreshProperties();
        }
    }

    public async void TakePhoto()
    {
        Stream stream = await new PhotoPickerService().GetImageStreamAsync();
        if (stream != null)
        {
            MemoryStream memory = new MemoryStream();
            await stream.CopyToAsync(memory);
            videoMaterial.Cover = memory.ToArray();
            RefreshProperties();
        }
    }

    public void RefreshProperties()
    {
        OnPropertyChanged("Name");
        OnPropertyChanged("Comment");
        OnPropertyChanged("Type");
        OnPropertyChanged("Cover");
    }
}

