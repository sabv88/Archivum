using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivum.Interfaces;

namespace Archivum.ViewModels.Games
{
    internal class GamesStatistickViewModel : BaseStatistickViewModel, IGamesStatistickViewModel
    {
        readonly IGamesStatictickService gamesStatictickService;

        public int GamesCount { get; set; }

        public GamesStatistickViewModel(IGamesStatictickService gamesStatictickService)
        {
            this.gamesStatictickService = gamesStatictickService;
            GetItemsAsync();
        }

        public async void GetItemsAsync()
        {
            GamesCount = await gamesStatictickService.GetGamesCountAsync();
            OnPropertyChanged(nameof(GamesCount));
        }

    }
}
