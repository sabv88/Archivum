using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace Archivum.ViewModels.Games
{
    public class GamesListViewModel : BaseListViewModel
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
        }

        public override async Task GetNextItemsAsync()
        {
            var gamesCollection = await listService.GetNextItemsAsync<GamesMaterial, GameViewModel>("GamesMaterial", 1, start);

            foreach (var item in gamesCollection)
            {
                Collection.Add(item);
            }

            start += 10;

            OnPropertyChanged("Collection");
        }

        public override Task TapItemAsync(IViewModel gamesMaterial)
        {
            return Shell.Current.GoToAsync($"gamesLibraryPage", true, new Dictionary<string, object>
            {
                ["ViewModel"] = gamesMaterial
            });
        }
    }
}
