using Archivum.Models;
using Archivum.ViewModels;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic
{
    class TextListService
    {
        readonly IRepository repository;

        public async Task<(int start, ObservableCollection<IViewModel> Collection)> GetNextItemsAsync(string filter, int start)
        {
            ObservableCollection<IViewModel> Collection = new();
            if (filter == "Все")
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
                if (filter == "Манга")
                {
                    filter = "Manga";
                }

                if (filter == "Книга")
                {
                    filter = "Book";
                }
                string query = "SELECT * FROM  [" + filter + "] ORDER BY Name LIMIT " + start + ", " + 10;
                var a = await repository.ExecuteRequest<Material>(query);
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var item in a)
                    {
                        Collection.Add(new VideoLibraryViewModel(item, new Repository()));
                    }

                });
                start += 10;
            }

            return (start, Collection);
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

    }
}
