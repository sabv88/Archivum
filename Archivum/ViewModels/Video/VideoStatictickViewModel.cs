using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Archivum.ViewModels.Video
{
    internal class VideoStatictickViewModel : INotifyPropertyChanged, IVideoStatistickViewModel
    {
        readonly IVideoStatictickService videoStatictickService;

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

        public int FilmsCount { get; set; }
        public int FilmlengthSum { get; set; }
        public int FilmlengthMax { get; set; }
        public int FilmlengthMin { get; set; }


        public int SeriesCount { get; set; }
        public int SeriesSeriesCount { get; set; }
        public int SerieslengthSum { get; set; }
        public int SeriesMaxSeriesCount { get; set; }
        public int SeriesMinSeriesCount { get; set; }
        public int SerieslengthMax { get; set; }
        public int SerieslengthMin { get; set; }



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
            AnimeWaifuCount = await videoStatictickService.GetAnimeWaifuCount();

            FilmsCount = await videoStatictickService.GetFilmCountAsync();
            FilmlengthSum = await videoStatictickService.GetFilmLengthSum();
            FilmlengthMax = await videoStatictickService.GetFilmMaxLength();
            FilmlengthMin = await videoStatictickService.GetFilmMinSeriesCount();

            SeriesCount = await videoStatictickService.GetSeriesCountAsync();
            SeriesSeriesCount = await videoStatictickService.GetSeriesSeriesCount();
            SerieslengthSum = await videoStatictickService.GetSeriesSeriesLengthSum();
            SeriesMaxSeriesCount = await videoStatictickService.GetSeriesMaxSeriesCount();
            SeriesMinSeriesCount = await videoStatictickService.GetSeriesMinSeriesCount();
            SerieslengthMax = await videoStatictickService.GetSeriesMaxSeriesLength();
            SerieslengthMin = await videoStatictickService.GetSeriesMinSeriesLength();

            AllCount = AnimeCount + FilmsCount + SeriesCount;
            AllTime = AnimeSeriesLengthSum + FilmlengthSum + SerieslengthSum;

            OnPropertyChanged("AnimeCount");
            OnPropertyChanged("AnimeSeriesCount");
            OnPropertyChanged("AnimeSeriesLengthSum");
            OnPropertyChanged("AnimeMaxSeriesCount");
            OnPropertyChanged("AnimeMinSeriesCount");
            OnPropertyChanged("AnimeMaxSeriesLength");
            OnPropertyChanged("AnimeMinSeriesLength");
            OnPropertyChanged("AnimeWaifuCount");

            OnPropertyChanged("FilmsCount");
            OnPropertyChanged("FilmlengthSum");
            OnPropertyChanged("FilmlengthMax");
            OnPropertyChanged("FilmlengthMin");

            OnPropertyChanged("SeriesCount");
            OnPropertyChanged("SeriesSeriesCount");
            OnPropertyChanged("SerieslengthSum");
            OnPropertyChanged("SeriesMaxSeriesCount");
            OnPropertyChanged("SeriesMinSeriesCount");
            OnPropertyChanged("SerieslengthMax");
            OnPropertyChanged("SerieslengthMin");

            OnPropertyChanged("AllCount");
            OnPropertyChanged("AllTime");
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
