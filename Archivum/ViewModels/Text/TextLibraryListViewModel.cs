using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models.Text;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace Archivum.ViewModels.Text;

public class TextLibraryListViewModel : BaseListViewModel, IRecipient<DeleteTextItemMessage>, IRecipient<AddTextItemMessage>
{

    public ICommand Statistick => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"textStatictickPage");
    });
    public ICommand AddItem => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"addPageText", true, new Dictionary<string, object>
        {
            ["AddViewModelText"] = new AddViewModelText(repository)
        });
    });
    public ICommand NextItems { get; }

    public TextLibraryListViewModel(IRepository repository, IlistService listService) : base(repository, listService)
    {
        TapItem = new AsyncRelayCommand<IViewModel>(TapItemAsync);
        NextItems = new AsyncRelayCommand(GetNextItemsAsync);
        WeakReferenceMessenger.Default.RegisterAll(this);
    }



    public override async Task GetNextItemsAsync()
    {
        if (filter == "Все")
        {
            var bookCollection = await listService.GetNextItemsAsync<Book, BookViewModel>("Book", start);
            var mangaCollection = await listService.GetNextItemsAsync<Manga, MangaViewModel>("Manga", start);
            var otherCollectoin = await listService.GetNextItemsAsync<TextMaterial, TextLibraryViewModel>("TextMaterial", start);

            foreach (var item in bookCollection)
            {
                Collection.Add(item);
            }
            foreach (var item in mangaCollection)
            {
                Collection.Add(item);
            }
            foreach (var item in otherCollectoin)
            {
                Collection.Add(item);
            }
        }
        else
        {
            if (filter == "Манга")
            {
                var mangaCollection = await listService.GetNextItemsAsync<Manga, MangaViewModel>("Manga", start);

                foreach (var item in mangaCollection)
                {
                    Collection.Add(item);
                }
                start += mangaCollection.Count;
            }

            if (filter == "Книга")
            {
                var bookCollection = await listService.GetNextItemsAsync<Book, BookViewModel>("Book", start);

                foreach (var item in bookCollection)
                {
                    Collection.Add(item);
                }
                start += bookCollection.Count;
            }
        }

        start += 10;
        OnPropertyChanged("Collection");
    }

    public override Task TapItemAsync(IViewModel textMaterial)
    {
        if (textMaterial.GetType() == typeof(BookViewModel))
        {
            return Shell.Current.GoToAsync($"bookPage", true, new Dictionary<string, object>
            {
                ["bookViewModel"] = textMaterial
            });
        }

        if (textMaterial.GetType() == typeof(MangaViewModel))
        {
            return Shell.Current.GoToAsync($"mangaPage", true, new Dictionary<string, object>
            {
                ["mangaViewModel"] = textMaterial
            });
        }

        return Shell.Current.GoToAsync($"textlibraryPage", true, new Dictionary<string, object>
        {
            ["ViewModel"] = textMaterial
        });
    }

    public void Receive(DeleteTextItemMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            IViewModel matchedNote = Collection.FirstOrDefault((n) => n.ID == message.Value.ID && n.GetType() == message.Value.GetType());
            Collection.Remove(matchedNote);
            OnPropertyChanged("Collection");

        });
    }

    public void Receive(AddTextItemMessage message)
    {
        Collection.Add(message.Value);
        OnPropertyChanged("Collection");
    }
}