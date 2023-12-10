
using Archivum.Logic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Archivum.Interfaces;
using CommunityToolkit.Mvvm.Messaging;
using Archivum.Models.Video;

namespace Archivum.ViewModels.Video;

public class VideoLibraryListViewModel : BaseListViewModel, IRecipient<DeleteVideoItemMessage>, IRecipient<AddVideoItemMessage>
{   
    public ICommand Statistick => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"videoStatictickPage");
    });
    public ICommand AddItem => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"addPage", true, new Dictionary<string, object>
        {
            ["AddViewModel"] = new AddViewModel(repository)
        });
    });
    public ICommand NextItems { get; }

    public VideoLibraryListViewModel(IRepository repository, IlistService listService) : base(repository, listService)
    {
        TapItem = new AsyncRelayCommand<IViewModel>(TapItemAsync);
        NextItems = new AsyncRelayCommand(GetNextItemsAsync);
        WeakReferenceMessenger.Default.RegisterAll(this);
    }

    public override async Task GetNextItemsAsync()
    {
        if (Filter == "Все")
        {
            var animeCollection = await listService.GetNextItemsAsync<Anime, AnimeViewModel>("Anime", start);
            var filmCollection = await listService.GetNextItemsAsync<Film, FilmViewModel>("Film", start);
            var serialCollectoin = await listService.GetNextItemsAsync<Serial, SerialViewModel>("Serial", start);
            var otherCollectoin = await listService.GetNextItemsAsync<VideoMaterial, VideoLibraryViewModel>("VideoMaterial", start);

            foreach (var item in animeCollection)
            {
                Collection.Add(item);
            }
            foreach (var item in filmCollection)
            {
                Collection.Add(item);
            }
            foreach (var item in serialCollectoin)
            {
                Collection.Add(item);
            }
            foreach (var item in otherCollectoin)
            {
                Collection.Add(item);
            }

            start += 10;

        }
        else
        {
            if (this.filter == "Аниме")
            {
                var animeCollection = await listService.GetNextItemsAsync<Anime, AnimeViewModel>("Anime", start);
                foreach (var item in animeCollection)
                {
                    Collection.Add(item);
                }
            }

            if (this.filter == "Фильм")
            {
                var filmCollection = await listService.GetNextItemsAsync<Film, FilmViewModel>("Film", start);
                foreach (var item in filmCollection)
                {
                    Collection.Add(item);
                }
            }

            if (this.filter == "Сериал")
            {
                var serialCollectoin = await listService.GetNextItemsAsync<Serial, SerialViewModel>("Serial", start);
                foreach (var item in serialCollectoin)
                {
                    Collection.Add(item);
                }
            }
        }

        start += 10;
        OnPropertyChanged("Collection");

    }

    public override Task TapItemAsync(IViewModel videoMaterial)
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

    public void Receive(DeleteVideoItemMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            IViewModel matchedNote = Collection.FirstOrDefault((n) => n.ID == message.Value.ID && n.GetType() == message.Value.GetType());
            Collection.Remove(matchedNote);
            OnPropertyChanged("Collection");
        });
    }

    public void Receive(AddVideoItemMessage message)
    {
        Collection.Add(message.Value);
        OnPropertyChanged("Collection");
    }
}



