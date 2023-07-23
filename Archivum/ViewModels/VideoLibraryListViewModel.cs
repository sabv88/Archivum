
using Archivum.Logic;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Archivum.Views;

namespace Archivum;
internal class VideoLibraryListViewModel : ObservableObject, INotifyPropertyChanged
{
    readonly VideoLibraryRepository database = new VideoLibraryRepository();
    public ObservableCollection<VideoLibraryViewModel> videoMaterials { get; set; } = new();
    public event PropertyChangedEventHandler? PropertyChanged;

    int start = 0;
   
    public ICommand TapItem { get; }
    public ICommand Statistick => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"videoStatictickPage");
    });
    public ICommand GetItems { get; }
    public ICommand AddItem => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"videolibraryPage", true, new Dictionary<string, object>
        {
            ["videoMaterial"] = null
        });
    });
    public ICommand Search => new Command<string>(async (string query) =>
    {
        videoMaterials.Clear();
        var searchRes = await database.GetSearchResults(query);
        MainThread.BeginInvokeOnMainThread(() =>
        {
            foreach (var item in searchRes)
            {
                videoMaterials.Add(new VideoLibraryViewModel(item));
            }
        });
        OnPropertyChanged("videoMaterials");

    });
    public ICommand ClearSearch => new Command<string>(async (string query) =>
    {

        videoMaterials.Clear();
        start = 0;
        Filter = "Все";
    });
    public ICommand next { get; }

    private string filter;

    public string Filter
    {
        set
        {
            start = 0;
            filter = value;
            videoMaterials.Clear();
            _ = GetNextItemsAsync(value);
        }
        get
        {
            return filter;
        }
    }

    VideoLibraryViewModel selectedVM;

    public VideoLibraryViewModel SelectedVM
    {
        get { return selectedVM; }
        set
        {
            if (selectedVM != value)
            {
                VideoLibraryViewModel tempVM = value;
                selectedVM = null;
                OnPropertyChanged("SelectedVM");
                TapItemAsync(tempVM);
            }
        }
    }

    public VideoLibraryListViewModel()
    {
        Filter = "Все";
        Subsribes();
        GetItems = new Command(GetItemsAsync);
        TapItem = new AsyncRelayCommand<VideoLibraryViewModel>(TapItemAsync);
        next = new AsyncRelayCommand<string>(GetNextItemsAsync);

    }

    public async void GetItemsAsync()
    {
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            videoMaterials.Clear();
            foreach (var item in items)
            {
                videoMaterials.Add(new VideoLibraryViewModel(item));
            }

        });
        OnPropertyChanged("videoMaterials");
    }

    public async Task GetNextItemsAsync(string filter)
    {
        if (Filter == "Все")
        {

            var a = await database.GetItemsToListAsync(start);
            start += 5;
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in a)
                {
                    videoMaterials.Add(new VideoLibraryViewModel(item));
                }

            });
        }
        else
        {
            var a = await database.GetItemsToListAsync(start, Filter);
            start += 5;
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in a)
                {
                    videoMaterials.Add(new VideoLibraryViewModel(item));
                }

            });
            OnPropertyChanged("videoMaterials");
        }

    }

    public async Task TapItemAsync(VideoLibraryViewModel videoMaterial)
    {
        await Shell.Current.GoToAsync($"videolibraryPage", true, new Dictionary<string, object>
        {
            ["videoMaterial"] = videoMaterial.videoMaterial
        });
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public void Subsribes()
    {
        MessagingCenter.Subscribe<VideoLibraryViewModel>(this, "Remove video element", (sender) =>
        {
            if (sender != null)
            {
                VideoLibraryViewModel matchedNote = videoMaterials.Where((n) => n.videoMaterial.ID == sender.videoMaterial.ID).FirstOrDefault();
                videoMaterials.Remove(matchedNote);
                OnPropertyChanged("videoMaterials");
            }
        });
        MessagingCenter.Subscribe<VideoLibraryViewModel>(this, "Change video element", (sender) =>
        {
            VideoLibraryViewModel matchedNotevideoMaterials = videoMaterials.Where((n) => n.videoMaterial.ID == sender.videoMaterial.ID).FirstOrDefault();
            if (matchedNotevideoMaterials != null)
            {
                matchedNotevideoMaterials.RefreshProperties();
            }

        });
    }

    bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        if (Object.Equals(storage, value))
            return false;

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}



