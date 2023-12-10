using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace Archivum.ViewModels.Games
{
    public class GamesListViewModel : BaseListViewModel, IRecipient<DeleteGamesItemMessage>, IRecipient<AddGamesItemMessage>
    {
        public ICommand Statistick => new Command(async () =>
        {
            await Shell.Current.GoToAsync($"gamesStatictickPage");
        });

        public ICommand AddItem => new Command(async () =>
        {
            await Shell.Current.GoToAsync($"addPageGames", true, new Dictionary<string, object>
            {
                ["AddViewModelGames"] = new AddGamesViewModel(repository)
            });
        });
        public ICommand NextItems { get; }

        public GamesListViewModel(IRepository repository, IlistService listService) : base(repository, listService)
        {
            TapItem = new AsyncRelayCommand<IViewModel>(TapItemAsync);
            NextItems = new AsyncRelayCommand(GetNextItemsAsync);
            WeakReferenceMessenger.Default.RegisterAll(this);
            _ = GetNextItemsAsync();
        }

        public override async Task GetNextItemsAsync()
        {
            var gamesCollection = await listService.GetNextItemsAsync<GamesMaterial, GameViewModel>("GamesMaterial", start);

            foreach (var item in gamesCollection)
            {
                Collection.Add(item);
            }

            start += 10;

            OnPropertyChanged("Collection");
        }

        public override Task TapItemAsync(IViewModel gamesMaterial)
        {
            return Shell.Current.GoToAsync($"gameslibraryPage", true, new Dictionary<string, object>
            {
                ["ViewModel"] = gamesMaterial
            });
        }

        public void Receive(DeleteGamesItemMessage message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                IViewModel matchedNote = Collection.FirstOrDefault((n) => n.ID == message.Value.ID && n.GetType() == message.Value.GetType());
                Collection.Remove(matchedNote);
                OnPropertyChanged("Collection");
            });
        }

        public void Receive(AddGamesItemMessage message)
        {
            Collection.Add(message.Value);
            OnPropertyChanged("Collection");
        }
    }
}
