using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivum.Interfaces;
using Microcharts;
using SkiaSharp;

namespace Archivum.ViewModels.Games
{
    internal class GamesStatistickViewModel : BaseStatistickViewModel, IGamesStatistickViewModel
    {
        readonly IGamesStatictickService gamesStatictickService;
        public int GamesWatchedCount { get; set; }
        public int GamesInProgressCount { get; set; }
        public int GamesDroppedCount { get; set; }
        public int GamesInPlanCount { get; set; }
        public int GamesCount { get; set; }
        public RadarChart GamesStatusChart { get; set; }

        public GamesStatistickViewModel(IGamesStatictickService gamesStatictickService)
        {
            this.gamesStatictickService = gamesStatictickService;
            GetItemsAsync();
        }

        public async void GetItemsAsync()
        {
            GamesCount = await gamesStatictickService.GetGamesCountAsync();
            GamesWatchedCount = await gamesStatictickService.GetGamesWatchedCount();
            GamesInProgressCount = await gamesStatictickService.GetGamesInProgressCount();
            GamesDroppedCount = await gamesStatictickService.GetGamesDroppedCount();
            GamesInPlanCount = await gamesStatictickService.GetGamesInPlanCount();

            GamesStatusChart = new RadarChart()
            {
                BackgroundColor = SKColors.Black,

                Entries = new ChartEntry[]
              {

                    new ChartEntry(GamesWatchedCount)
                    {
                         Label = "Пройденно",
                         ValueLabel = GamesWatchedCount.ToString(),
                         Color = SKColor.Parse("#40E0D0"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                     new ChartEntry(GamesInProgressCount)
                    {
                         Label = "В процессе",
                         ValueLabel = GamesInProgressCount.ToString(),
                         Color = SKColor.Parse("#00BFFF"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                      new ChartEntry(GamesDroppedCount)
                    {
                         Label = "Брошено",
                         ValueLabel = GamesDroppedCount.ToString(),
                         Color = SKColor.Parse("#00008B"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                        new ChartEntry(GamesInPlanCount)
                    {
                         Label = "В планах",
                         ValueLabel = GamesInPlanCount.ToString(),
                         Color = SKColor.Parse("#7FFFD4"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
              }
            };
            OnPropertyChanged(nameof(GamesStatusChart));
            OnPropertyChanged(nameof(GamesCount));
        }

    }
}
