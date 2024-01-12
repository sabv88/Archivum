using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microcharts;
using SkiaSharp;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Archivum.ViewModels.Video
{
    internal class VideoStatictickViewModel : INotifyPropertyChanged, IVideoStatistickViewModel
    {
        readonly IVideoStatictickService videoStatictickService;

        public DonutChart TypesChart { get; set; }
        public BarChart AllTimeChart { get; set; }
        public RadialGaugeChart AnimeStatusChart { get; set; }
        public RadialGaugeChart FilmStatusChart { get; set; }
        public RadialGaugeChart SerialStatusChart { get; set; }

        public int AllCount { get; set; }
        public int AllTime { get; set; }

        public int AnimeCount { get; set; }
        public int AnimeSeriesCount { get; set; }
        public int AnimeSeriesLengthSum { get; set; }
        public int AnimeMaxSeriesCount { get; set; }
        public int AnimeMinSeriesCount { get; set; }
        public int AnimeMaxSeriesLength { get; set; }
        public int AnimeMinSeriesLength { get; set; }
        public int AnimeWaifuCount { get; set; }
        public int AnimeWatchedCount { get; set; }
        public int AnimeInProgressCount { get; set; }
        public int AnimeDroppedCount { get; set; }
        public int AnimeInPlanCount { get; set; }


        public int FilmsCount { get; set; }
        public int FilmlengthSum { get; set; }
        public int FilmlengthMax { get; set; }
        public int FilmlengthMin { get; set; }
        public int FilmWatchedCount { get; set; }
        public int FilmInProgressCount { get; set; }
        public int FilmDroppedCount { get; set; }
        public int FilmInPlanCount { get; set; }


        public int SeriesCount { get; set; }
        public int SeriesSeriesCount { get; set; }
        public int SerieslengthSum { get; set; }
        public int SeriesMaxSeriesCount { get; set; }
        public int SeriesMinSeriesCount { get; set; }
        public int SerieslengthMax { get; set; }
        public int SerieslengthMin { get; set; }
        public int SeriesWatchedCount { get; set; }
        public int SeriesInProgressCount { get; set; }
        public int SeriesDroppedCount { get; set; }
        public int SeriesInPlanCount { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public VideoStatictickViewModel(IVideoStatictickService videoStatictickService )
        {
            this.videoStatictickService = videoStatictickService;
            GetItemsAsync();
        }

        public async void GetItemsAsync()
        {
            AnimeCount = await videoStatictickService.GetAnimeCountAsync();
            AnimeSeriesCount = await videoStatictickService.GetAnimeSeriesCount();
            AnimeSeriesLengthSum = await videoStatictickService.GetAnimeSeriesLengthSum();
            AnimeMaxSeriesCount = await videoStatictickService.GetAnimeMaxSeriesCount();
            AnimeMinSeriesCount = await videoStatictickService.GetAnimeMinSeriesCount();
            AnimeMaxSeriesLength = await videoStatictickService.GetAnimeMaxSeriesLength();
            AnimeMinSeriesLength = await videoStatictickService.GetAnimeMinSeriesLength();
            AnimeWatchedCount = await videoStatictickService.GetAnimeWatchedCount();
            AnimeInProgressCount = await videoStatictickService.GetAnimeInProgressCount();
            AnimeDroppedCount = await videoStatictickService.GetAnimeDroppedCount();
            AnimeInPlanCount = await videoStatictickService.GetAnimeInPlanCount();

            FilmsCount = await videoStatictickService.GetFilmCountAsync();
            FilmlengthSum = await videoStatictickService.GetFilmLengthSum();
            FilmlengthMax = await videoStatictickService.GetFilmMaxLength();
            FilmlengthMin = await videoStatictickService.GetFilmMinSeriesCount();
            FilmWatchedCount = await videoStatictickService.GetFilmWatchedCount();
            FilmInProgressCount = await videoStatictickService.GetFilmInProgressCount();
            FilmDroppedCount = await videoStatictickService.GetFilmDroppedCount();
            FilmInPlanCount = await videoStatictickService.GetFilmInPlanCount();

            SeriesCount = await videoStatictickService.GetSeriesCountAsync();
            SeriesSeriesCount = await videoStatictickService.GetSeriesSeriesCount();
            SerieslengthSum = await videoStatictickService.GetSeriesSeriesLengthSum();
            SeriesMaxSeriesCount = await videoStatictickService.GetSeriesMaxSeriesCount();
            SeriesMinSeriesCount = await videoStatictickService.GetSeriesMinSeriesCount();
            SerieslengthMax = await videoStatictickService.GetSeriesMaxSeriesLength();
            SerieslengthMin = await videoStatictickService.GetSeriesMinSeriesLength();
            SeriesWatchedCount = await videoStatictickService.GetFilmWatchedCount();
            SeriesInProgressCount = await videoStatictickService.GetFilmInProgressCount();
            SeriesDroppedCount = await videoStatictickService.GetFilmDroppedCount();
            SeriesInPlanCount = await videoStatictickService.GetFilmInPlanCount();

            AllCount = AnimeCount + FilmsCount + SeriesCount;
            AllTime = AnimeSeriesLengthSum + FilmlengthSum + SerieslengthSum;

            AnimeStatusChart = new RadialGaugeChart()
            {
                BackgroundColor = SKColors.Black,

                Entries = new ChartEntry[]
               {

                    new ChartEntry(AnimeWatchedCount)
                    {
                         Label = "Просмотренно",
                         ValueLabel = AnimeWatchedCount.ToString(),
                         Color = SKColor.Parse("#90EE90"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                     new ChartEntry(AnimeInProgressCount)
                    {
                         Label = "В процессе",
                         ValueLabel = AnimeInProgressCount.ToString(),
                         Color = SKColor.Parse("#32CD32"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                      new ChartEntry(AnimeDroppedCount)
                    {
                         Label = "Брошено",
                         ValueLabel = AnimeDroppedCount.ToString(),
                         Color = SKColor.Parse("#00FF7F"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                        new ChartEntry(AnimeInPlanCount)
                    {
                         Label = "В планах",
                         ValueLabel = AnimeInPlanCount.ToString(),
                         Color = SKColor.Parse("#006400"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
               }
            };

            SerialStatusChart = new RadialGaugeChart()
            {
                BackgroundColor = SKColors.Black,

                Entries = new ChartEntry[]
            {

                    new ChartEntry(SeriesWatchedCount)
                    {
                         Label = "Просмотренно",
                         ValueLabel = SeriesWatchedCount.ToString(),
                         Color = SKColor.Parse("#F0E68C"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                     new ChartEntry(SeriesInProgressCount)
                    {
                         Label = "В процессе",
                         ValueLabel = SeriesInProgressCount.ToString(),
                         Color = SKColor.Parse("#FFDAB9"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                      new ChartEntry(SeriesDroppedCount)
                    {
                         Label = "Брошено",
                         ValueLabel = SeriesDroppedCount.ToString(),
                         Color = SKColor.Parse("#FAEBD7"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                        new ChartEntry(SeriesInPlanCount)
                    {
                         Label = "В планах",
                         ValueLabel = SeriesInPlanCount.ToString(),
                         Color = SKColor.Parse("#FFE4E1"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
            }
            };

            FilmStatusChart = new RadialGaugeChart()
            {
                BackgroundColor = SKColors.Black,

                Entries = new ChartEntry[]
            {

                    new ChartEntry(FilmWatchedCount)
                    {
                         Label = "Просмотренно",
                         ValueLabel = FilmWatchedCount.ToString(),
                         Color = SKColor.Parse("#BA55D3"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                     new ChartEntry(FilmInProgressCount)
                    {
                         Label = "В процессе",
                         ValueLabel = FilmInProgressCount.ToString(),
                         Color = SKColor.Parse("#9370DB"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                      new ChartEntry(FilmDroppedCount)
                    {
                         Label = "Брошено",
                         ValueLabel = FilmDroppedCount.ToString(),
                         Color = SKColor.Parse("#EE82EE"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                        new ChartEntry(FilmInPlanCount)
                    {
                         Label = "В планах",
                         ValueLabel = FilmInPlanCount.ToString(),
                         Color = SKColor.Parse("#DDA0DD"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
            }
            };

            TypesChart = new DonutChart()
            {
                BackgroundColor = SKColor.Parse("#1f3438"),

                Entries = new ChartEntry[]
                {

                    new ChartEntry(AnimeCount)
                    {
                         Label = "Аниме",
                         ValueLabel = AnimeCount.ToString(),
                         Color = SKColor.Parse("#4d5645"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                     new ChartEntry(FilmsCount)
                    {
                         Label = "Фильмы",
                         ValueLabel = FilmsCount.ToString(),
                         Color = SKColor.Parse("#543964"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                      new ChartEntry(SeriesCount)
                    {
                         Label = "Сериалы",
                         ValueLabel = SeriesCount.ToString(),
                         Color = SKColor.Parse("#7d7f7d"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                }
            };

            AllTimeChart = new BarChart()
            {
                BackgroundColor = SKColor.Parse("#003841"),
                LabelColor = SKColors.White,
                Entries = new ChartEntry[]
               {

                    new ChartEntry(AnimeSeriesLengthSum)
                    {
                         Label = "Аниме",
                         ValueLabel = AnimeSeriesLengthSum.ToString(),
                         Color = SKColor.Parse("#424632"),
                         ValueLabelColor = SKColors.White,
                         OtherColor = SKColors.White,
                         TextColor = SKColors.White
                        
                    },
                     new ChartEntry(FilmlengthSum)
                    {
                         Label = "Фильмы",
                         ValueLabel = FilmlengthSum.ToString(),
                         Color = SKColor.Parse("#3a2745"),
                         ValueLabelColor = SKColors.White,
                         OtherColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                      new ChartEntry(SerieslengthSum)
                    {
                         Label = "Сериалы",
                         ValueLabel = SerieslengthSum.ToString(),
                         Color = SKColor.Parse("#7f7679"),
                         ValueLabelColor = SKColors.White,
                         OtherColor = SKColors.White,
                         TextColor = SKColors.White
                    },
               }
            };
            OnPropertyChanged(nameof(AnimeCount));
            OnPropertyChanged(nameof(AnimeSeriesCount));
            OnPropertyChanged(nameof(AnimeSeriesLengthSum));
            OnPropertyChanged(nameof(AnimeMaxSeriesCount));
            OnPropertyChanged(nameof(AnimeMinSeriesCount));
            OnPropertyChanged(nameof(AnimeMaxSeriesLength));
            OnPropertyChanged(nameof(AnimeMinSeriesLength));
            OnPropertyChanged(nameof(AnimeWaifuCount));

            OnPropertyChanged(nameof(FilmsCount));
            OnPropertyChanged(nameof(FilmlengthSum));
            OnPropertyChanged(nameof(FilmlengthMax));
            OnPropertyChanged(nameof(FilmlengthMin));

            OnPropertyChanged(nameof(SeriesCount));
            OnPropertyChanged(nameof(SeriesSeriesCount));
            OnPropertyChanged(nameof(SerieslengthSum));
            OnPropertyChanged(nameof(SeriesMaxSeriesCount));
            OnPropertyChanged(nameof(SeriesMinSeriesCount));
            OnPropertyChanged(nameof(SerieslengthMax));
            OnPropertyChanged(nameof(SerieslengthMin));

            OnPropertyChanged(nameof(AllCount));
            OnPropertyChanged(nameof(AllTime));
            OnPropertyChanged(nameof(TypesChart));
            OnPropertyChanged(nameof(AllTimeChart));
            OnPropertyChanged(nameof(AnimeStatusChart));
            OnPropertyChanged(nameof(FilmStatusChart));
            OnPropertyChanged(nameof(SerialStatusChart));
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
