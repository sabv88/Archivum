using Archivum.Logic;
using Archivum.Models;
using Archivum.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Archivum;

public class TextLibraryListViewModel : INotifyPropertyChanged
{
    readonly IRepository repository;
    public ObservableCollection<IViewModel> Collection { get; set; } = new();
    public event PropertyChangedEventHandler? PropertyChanged;
    int start = 0;
    string filter;
    IViewModel selectedVM;

    public string Filter
    { 
        get
        {
            return filter;
        }
        set
        {
            start = 0;
            filter = value;
            Collection.Clear();
            _ = GetNextItemsAsync(value);
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
        await Shell.Current.GoToAsync($"textStatictickPage");
    });
    public ICommand GetItems { get; }
    public ICommand AddItem => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"addPageText", true, new Dictionary<string, object>
        {
            ["AddViewModelText"] = new AddViewModelText(repository)
        });
    });
    public ICommand Search => new Command<string>(async (string query) =>
    {
        //textMaterials.Clear();
        //string Request = "SELECT * FROM [TextMaterial] Where Name LIKE '" + query + "'";
        //var searchRes = await database.ExecuteRequest<Material>(Request);
        //MainThread.BeginInvokeOnMainThread(() =>
        //{
        //    foreach (var item in searchRes)
        //    {
        //        textMaterials.Add(new TextLibraryViewModel(item));
        //    }
        //});

        //OnPropertyChanged("textMaterials");

    });
    public ICommand ClearSearch => new Command<string>(async (string query) =>
    {

        Collection.Clear();
        start = 0;
        Filter = "Все";
    });
    public ICommand next { get; }
    public ICommand prev { get; }



    public TextLibraryListViewModel(IRepository repository)
    {
        this.repository = repository;
        Subsribes();
        GetItems = new AsyncRelayCommand<string>(GetPrevItemsAsync);
        TapItem = new AsyncRelayCommand<IViewModel>(TapItemAsync);
        next = new AsyncRelayCommand<string>(GetNextItemsAsync);

    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }

    public async Task GetPrevItemsAsync(string filter)
    {
        if(start - 10 < 0)
        {
            start = 0;
        }
        else
        {
            start -= 10;
        }

        _ = GetNextItemsAsync(filter);
    }


    public async Task GetNextItemsAsync(string filter)
    {
        if (Filter == "Все")
        {
            string query = "SELECT * FROM  [Book] ORDER BY Name LIMIT " + start + ", " + 10;
            var bookList = await repository.ExecuteRequest<Book>(query);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in bookList)
                {
                    BookViewModel material = new(item.ID, item.Name, item.Cover, new Repository(), item.Comment, item.PagesAmount);
                    Collection.Add(material);
                }

            });

            query = "SELECT * FROM [Manga] ORDER BY Name LIMIT " + start + ", " + 10;
            var mangaList = await repository.ExecuteRequest<Manga>(query);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in mangaList)
                {
                    MangaViewModel material = new(item.ID, item.Name, item.Cover, new Repository(), item.Comment, item.PagesAmount);
                    Collection.Add(material);
                }

            });

            query = "SELECT * FROM [TextMaterial] ORDER BY Name LIMIT " + start + ", " + 10;
            var a1 = await repository.ExecuteRequest<Material>(query);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in a1)
                {
                    Collection.Add(new TextLibraryViewModel(item, new Repository()));
                }

            });
            start += 10;

        }
        else
        {
            if (this.filter == "Манга")
            {
                string query = "SELECT * FROM  [Manga] ORDER BY Name LIMIT " + start + ", " + 10;
                var a = await repository.ExecuteRequest<Manga>(query);
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var item in a)
                    {
                        Collection.Add(new MangaViewModel(item.ID, item.Name, item.Cover, repository, item.Comment, item.PagesAmount));
                    }

                });
            }

            if (this.filter == "Книга")
            {
                string query = "SELECT * FROM  [Book] ORDER BY Name LIMIT " + start + ", " + 10;
                var a = await repository.ExecuteRequest<Book>(query);
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var item in a)
                    {
                        Collection.Add(new BookViewModel(item.ID, item.Name, item.Cover, repository, item.Comment, item.PagesAmount));
                    }

                });
            }
            
            start += 10;

        }
        OnPropertyChanged("videoMaterials");
    }



    public Task TapItemAsync(IViewModel textMaterial)
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

    public async void AddItemAsync()
    {
        await Shell.Current.GoToAsync($"textLibraryPage", true, new Dictionary<string, object>
        {
            ["textMaterial"] = null
        });
    }
    public void Subsribes()
    {
        MessagingCenter.Subscribe<IViewModel>(this, "Remove text element", (sender) =>
        {
            IViewModel matchedNote = Collection.Where((n) => n.ID == sender.ID && n.GetType() == sender.GetType()).FirstOrDefault();
            Collection.Remove(matchedNote);
            OnPropertyChanged("textMaterials");
        });
        MessagingCenter.Subscribe<IViewModel>(this, "Change text element", (sender) =>
        {
            IViewModel matchedNote = Collection.Where((n) => n.ID == sender.ID && n.GetType() == sender.GetType()).FirstOrDefault();
            Collection.Remove(matchedNote);
            OnPropertyChanged("textMaterials");
            if (matchedNote != null)
            {
                matchedNote.RefreshProperties();
            }
        });
    }
}