using Archivum.Logic;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Archivum;

internal class TextLibraryListViewModel : INotifyPropertyChanged
{
    readonly TextLibraryRepository database = new TextLibraryRepository();
    public event PropertyChangedEventHandler PropertyChanged;
    public ObservableCollection<TextLibraryViewModel> textMaterials { get; set; } = new();

    int start = 0;
  
    private string filter;

    public string Filter
    {
        set
        {
            start = 0;
            filter = value;
            textMaterials.Clear();
            _ = GetNextItemsAsync(value);
        }
        get
        {
            return filter;
        }
    }


    public ICommand TapItem { get; }
    public ICommand Statistick => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"textStatictickPage");
    });
    public ICommand GetItems { get; }
    public ICommand AddItem { get; }
    public ICommand Search => new Command<string>(async (string query) =>
    {
        textMaterials.Clear();
        var searchRes = await database.GetSearchResults(query);
        MainThread.BeginInvokeOnMainThread(() =>
        {
            foreach (var item in searchRes)
            {
                textMaterials.Add(new TextLibraryViewModel(item));
            }
        });

        OnPropertyChanged("textMaterials");

    });
    public ICommand ClearSearch => new Command<string>(async (string query) =>
    {

        textMaterials.Clear();
        start = 0;
        Filter = "Все";
    });
    public ICommand next { get; }

    TextLibraryViewModel selectedVM;
    public TextLibraryViewModel SelectedVM
    {
        get { return selectedVM; }
        set
        {
            if (selectedVM != value)
            {
                TextLibraryViewModel tempVM = value;
                selectedVM = null;
                OnPropertyChanged("SelectedVM");
                TapItemAsync(tempVM);
            }
        }
    }

    public TextLibraryListViewModel()
    {
        Subsribes();
        Filter = "Все";
        GetItems = new Command(GetItemsAsync);
        AddItem = new Command(AddItemAsync);
        TapItem = new AsyncRelayCommand<TextLibraryViewModel>(TapItemAsync);
        next = new AsyncRelayCommand<string>(GetNextItemsAsync);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }

    public async void GetItemsAsync()
    {
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            textMaterials.Clear();
            foreach (var item in items)
            {
                textMaterials.Add(new TextLibraryViewModel(item));
            }

        });

        OnPropertyChanged("textMaterials");
    }

    public async void GetNextItemsAsync()
    {
        var a = await database.GetItemsToListAsync(start);
        start += 5;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            foreach (var item in a)
            {
                textMaterials.Add(new TextLibraryViewModel(item));
            }

        });
        OnPropertyChanged("textMaterials");
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
                    textMaterials.Add(new TextLibraryViewModel(item));
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
                    textMaterials.Add(new TextLibraryViewModel(item));
                }

            });
            OnPropertyChanged("videoMaterials");
        }

    }

    public async Task TapItemAsync(TextLibraryViewModel textMaterial)
    {
        await Shell.Current.GoToAsync($"textlibraryPage", true, new Dictionary<string, object>
        {
            ["textMaterial"] = textMaterial.textMaterial
        });
    }
    public async void AddItemAsync()
    {
        await Shell.Current.GoToAsync($"textLibraryPage", true, new Dictionary<string, object>
        {
            ["textMaterial"] = null
        });
    }
    public void Subsribes()
    {
        MessagingCenter.Subscribe<TextLibraryViewModel>(this, "Remove text element", (sender) =>
        {
            if (sender != null)
            {
                TextLibraryViewModel matchedNote = textMaterials.Where((n) => n.textMaterial.ID == sender.textMaterial.ID).FirstOrDefault();
                textMaterials.Remove(matchedNote);
                OnPropertyChanged("textMaterials");
            }
        });
        MessagingCenter.Subscribe<TextLibraryViewModel>(this, "Change text element", (sender) =>
        {
            TextLibraryViewModel matchedNotevideoMaterials = textMaterials.Where((n) => n.textMaterial.ID == sender.textMaterial.ID).FirstOrDefault();
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
