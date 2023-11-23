
using Archivum.Logic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using Archivum.ViewModels;
using Archivum.Models;
namespace Archivum;

public partial class VideoLibraryListViewModel : BaseViewModel, INotifyPropertyChanged, IListView
{
    readonly IRepository repository;
    public ObservableCollection<IViewModel> Collection { get; set; } = new();
    public event PropertyChangedEventHandler? PropertyChanged;
    int start = 0;
    string filter;
    IViewModel selectedVM;

    public string Filter
    {
        set
        {
            start = 0;
            filter = value;
            Collection.Clear();
            _ = GetNextItemsAsync(value);
        }
        get
        {
            return filter;
        }
    }

    public IViewModel SelectedVM
    {
        get { return selectedVM; }
        set
        {
            if (selectedVM != value)
            {
                IViewModel tempVM = value;
                selectedVM = null;
                SelectedVM = null;
                OnPropertyChanged("SelectedVM");
                TapItemAsync(tempVM);
            }
        }
    }
    public ICommand TapItem { get; }
    public ICommand Statistick => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"videoStatictickPage");
    });
    public ICommand GetItems { get; }
    public ICommand AddItem => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"addPage", true, new Dictionary<string, object>
        {
            ["AddViewModel"] = new AddViewModel(repository)
        });
    });
    public ICommand Search => new Command<string>(async (string query) =>
    {
        //videoMaterials.Clear();
        //string Request = "SELECT * FROM [VideoMaterial] Where Name LIKE '" + query + "'";
        //var searchRes = await database.ExecuteRequest<VideoMaterial>(Request);
        //MainThread.BeginInvokeOnMainThread(() =>
        //{
        //    foreach (var item in searchRes)
        //    {
        //        videoMaterials.Add(new VideoLibraryViewModel(item));
        //    }
        //});
        //OnPropertyChanged("videoMaterials");
    });
    public ICommand ClearSearch => new Command<string>(async (string query) =>
    {
        Collection.Clear();
        start = 0;
        Filter = "Все";
    });
    public ICommand next { get; }





    public VideoLibraryListViewModel(IRepository repository)
    {
        this.repository = repository;
        Filter = "Все";
        Subsribes();
        GetItems = new Command(GetItemsAsync);
        TapItem = new AsyncRelayCommand<IViewModel>(TapItemAsync);
        next = new AsyncRelayCommand<string>(GetNextItemsAsync);

    }

    public async void GetItemsAsync()
    {
        var items = await repository.GetItemsAsync<Material>();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Collection.Clear();
            foreach (var item in items)
            {
                Collection.Add(new VideoLibraryViewModel(item, new Repository()));
            }

        });
        OnPropertyChanged("videoMaterials");
    }

    public async Task GetNextItemsAsync(string filter)
    {
        if (Filter == "Все")
        {
            string query = "SELECT * FROM [Anime] LIMIT " + start + ", " + 2;
            var animeList = await repository.ExecuteRequest<Anime>(query);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in animeList)
                {
                    AnimeViewModel material = new(item.ID, item.Name, item.Cover, new Repository(), item.Comment, item.SeriesCount, item.Serieslength, item.Waifu);
                    Collection.Add(material);
                }

            });

            query = "SELECT * FROM [Film] LIMIT " + start + ", " + 2;
            var filmList = await repository.ExecuteRequest<Film>(query);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in filmList)
                {
                    FilmViewModel material = new(item.ID, item.Name, item.Cover, new Repository(), item.Filmlength, item.Comment);
                    Collection.Add(material);
                }

            });

            query = "SELECT * FROM [Serial] LIMIT " + start + ", " + 2;
            var serialList = await repository.ExecuteRequest<Serial>(query);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in serialList)
                {
                    SerialViewModel material = new(item.ID, item.Name, item.Cover, new Repository(), item.Comment, item.SeriesCount, item.Serieslength);
                    Collection.Add(material);
                }

            });

            query = "SELECT * FROM [VideoMaterial] LIMIT " + start + ", " + 2;
            var a1 = await repository.ExecuteRequest<Material>(query);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in a1)
                {
                    Collection.Add(new VideoLibraryViewModel(item, new Repository()));
                }

            });
            start += 2;

        }
        else
        {
            if(Filter == "Аниме")
            {
                Filter = "Anime";
            }

            if (Filter == "Фильм")
            {
                Filter = "Film";
            }

            if (Filter == "Сериал")
            {
                Filter = "Serial";
            }

            string query = "SELECT * FROM ["+ Filter + "]";
            var a = await repository.ExecuteRequest<Material>(query);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in a)
                {
                    Collection.Add(new VideoLibraryViewModel(item, new Repository()));
                }

            });
            start += 2;

        }
            OnPropertyChanged("videoMaterials");

    }

    public Task TapItemAsync(IViewModel videoMaterial)
    {
        if (videoMaterial.GetType() == typeof(AnimeViewModel))
        {
            return Shell.Current.GoToAsync($"animePage", true, new Dictionary<string, object>
            {
                ["animeViewModel"] = videoMaterial
            });
        }
        if (videoMaterial.GetType() == typeof(SerialViewModel))
        {
            return Shell.Current.GoToAsync($"serialPage", true, new Dictionary<string, object>
            {
                ["serialViewModel"] = videoMaterial
            });
        }
        if (videoMaterial.GetType() == typeof(FilmViewModel))
        {
            return Shell.Current.GoToAsync($"filmPage", true, new Dictionary<string, object>
            {
                ["filmViewModel"] = videoMaterial
            });
        }
        return Shell.Current.GoToAsync($"videolibraryPage", true, new Dictionary<string, object>
            {
                ["ViewModel"] = videoMaterial
        });
        
       
    }

   

    public void Subsribes()
    {
        MessagingCenter.Subscribe<IViewModel>(this, "Remove video element", (sender) =>
        {
            IViewModel matchedNote = Collection.Where((n) => n.ID == sender.ID && n.GetType() == sender.GetType()).FirstOrDefault();
                Collection.Remove(matchedNote);
                OnPropertyChanged("videoMaterials");
        });
        MessagingCenter.Subscribe<IViewModel>(this, "Change video element", (sender) =>
        {
            IViewModel matchedNote = Collection.Where((n) => n.ID == sender.ID && n.GetType() == sender.GetType()).FirstOrDefault();
            Collection.Remove(matchedNote);
            OnPropertyChanged("videoMaterials");
            if (matchedNote != null)
            {
                matchedNote.RefreshProperties();
            }
        });
    }
}



