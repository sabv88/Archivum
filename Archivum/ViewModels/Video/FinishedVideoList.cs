using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models.Video;
using CommunityToolkit.Mvvm.Messaging;

namespace Archivum.ViewModels.Video
{
    public class FinishedVideoList : VideoLibraryListViewModel, IRecipient<DeleteVideoFinishedItemMessage>, IRecipient<AddVideoFinishedItemMessage>
    {
        public FinishedVideoList(IRepository repository, IlistService listService) : base(repository, listService)
        {
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        public override async Task GetNextItemsAsync()
        {
            if (Filter == "Все")
            {
                var animeCollection = await listService.GetNextItemsAsync<Anime, AnimeViewModel>("Anime", 1, start);
                var filmCollection = await listService.GetNextItemsAsync<Film, FilmViewModel>("Film", 1, start);
                var serialCollectoin = await listService.GetNextItemsAsync<Serial, SerialViewModel>("Serial", 1, start);
                var otherCollectoin = await listService.GetNextItemsAsync<VideoMaterial, VideoLibraryViewModel>("VideoMaterial", 1, start);

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
                    var animeCollection = await listService.GetNextItemsAsync<Anime, AnimeViewModel>("Anime", 1, start);
                    foreach (var item in animeCollection)
                    {
                        Collection.Add(item);
                    }
                }

                if (this.filter == "Фильм")
                {
                    var filmCollection = await listService.GetNextItemsAsync<Film, FilmViewModel>("Film", 1, start);
                    foreach (var item in filmCollection)
                    {
                        Collection.Add(item);
                    }
                }

                if (this.filter == "Сериал")
                {
                    var serialCollectoin = await listService.GetNextItemsAsync<Serial, SerialViewModel>("Serial", 1, start);
                    foreach (var item in serialCollectoin)
                    {
                        Collection.Add(item);
                    }
                }
            }

            start += 10;
            OnPropertyChanged("Collection");

        }

        public void Receive(DeleteVideoFinishedItemMessage message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                IViewModel matchedNote = Collection.FirstOrDefault((n) => n.ID == message.Value.ID && n.GetType() == message.Value.GetType());
                Collection.Remove(matchedNote);
                OnPropertyChanged("Collection");

            });
        }

        public void Receive(AddVideoFinishedItemMessage message)
        {
            Collection.Add(message.Value);
            OnPropertyChanged("Collection");
        }
    }
}
