using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Logic.Messages.Games;
using Archivum.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace Archivum.ViewModels.Games
{
    public class InProgressGamesList : GamesListViewModel , IRecipient<DeleteGamesItemInProgressMessage>, IRecipient<AddGamesInProgressItemMessage>
    {
        public InProgressGamesList(IRepository repository, IlistService listService) : base(repository, listService)
        {
            WeakReferenceMessenger.Default.RegisterAll(this);
            _ = GetNextItemsAsync();
        }

        public override async Task GetNextItemsAsync()
        {
            var gamesCollection = await listService.GetNextItemsAsync<GamesMaterial, GameViewModel>("GamesMaterial", 0, start);

            foreach (var item in gamesCollection)
            {
                Collection.Add(item);
            }

            start += 10;

            OnPropertyChanged("Collection");
        }

        public void Receive(DeleteGamesItemInProgressMessage message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                IViewModel matchedNote = Collection.FirstOrDefault((n) => n.ID == message.Value.ID && n.GetType() == message.Value.GetType());
                Collection.Remove(matchedNote);
                OnPropertyChanged("Collection");
            });
        }

        public void Receive(AddGamesInProgressItemMessage message)
        {
            Collection.Add(message.Value);
            OnPropertyChanged("Collection");
        }
    }
}
