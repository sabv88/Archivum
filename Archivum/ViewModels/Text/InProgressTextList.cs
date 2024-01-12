using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Logic.Messages.Text;
using Archivum.Models.Text;
using CommunityToolkit.Mvvm.Messaging;

namespace Archivum.ViewModels.Text
{
    public class InProgressTextList : TextLibraryListViewModel, IRecipient<DeleteTextInProgressItemMessage>, IRecipient<AddTextInProgressItemMessage>
    {
        public InProgressTextList(IRepository repository, IlistService listService) : base(repository, listService)
        {
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        public override async Task GetNextItemsAsync()
        {
            if (filter == "Все")
            {
                var bookCollection = await listService.GetNextItemsAsync<Book, BookViewModel>("Book", 0, start);
                var mangaCollection = await listService.GetNextItemsAsync<Manga, MangaViewModel>("Manga", 0, start);
                var otherCollectoin = await listService.GetNextItemsAsync<TextMaterial, TextLibraryViewModel>("TextMaterial", 0, start);

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
                    var mangaCollection = await listService.GetNextItemsAsync<Manga, MangaViewModel>("Manga", 0, start);

                    foreach (var item in mangaCollection)
                    {
                        Collection.Add(item);
                    }
                    start += mangaCollection.Count;
                }

                if (filter == "Книга")
                {
                    var bookCollection = await listService.GetNextItemsAsync<Book, BookViewModel>("Book", 0, start);

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

        public void Receive(DeleteTextInProgressItemMessage message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                IViewModel matchedNote = Collection.FirstOrDefault((n) => n.ID == message.Value.ID && n.GetType() == message.Value.GetType());
                Collection.Remove(matchedNote);
                OnPropertyChanged("Collection");

            });
        }

        public void Receive(AddTextInProgressItemMessage message)
        {
                Collection.Add(message.Value);
                OnPropertyChanged("Collection");
        }

    }
}
