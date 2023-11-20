using Archivum.Logic;
using Archivum.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Archivum.ViewModels
{
    internal class VideoStatictickViewModel : INotifyPropertyChanged
    {
        VideoStatictickService videoStatictickService;
        IRepository repository;

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

        public VideoStatictickViewModel(IRepository repository)
        {
            this.repository = repository;
            videoStatictickService = new VideoStatictickService(repository);
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

            SeriesCount = await videoStatictickService.GetAnimeCountAsync();
            SeriesSeriesCount = await videoStatictickService.GetAnimeSeriesCount();
            SerieslengthSum = await videoStatictickService.GetAnimeSeriesLengthSum();
            SeriesMaxSeriesCount = await videoStatictickService.GetAnimeMaxSeriesCount();
            SeriesMinSeriesCount = await videoStatictickService.GetAnimeMinSeriesCount();
            SerieslengthMax = await videoStatictickService.GetAnimeMaxSeriesLength();
            SerieslengthMin = await videoStatictickService.GetAnimeMinSeriesLength();

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
