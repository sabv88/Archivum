using Archivum.Logic;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Archivum.ViewModels
{
    internal class VideoStatictickViewModel : INotifyPropertyChanged
    {   
        readonly VideoLibraryRepository database = new VideoLibraryRepository();
        public int AllCount { get; set; }
        public int AnimeCount { get; set; }
        public int FilmsCount { get; set; }
        public int SeriesCount { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public VideoStatictickViewModel()
        {
            GetItemsAsync();
        }
        public async void GetItemsAsync()
        {
            AnimeCount = await database.GetCount("Аниме");
            FilmsCount = await database.GetCount("Фильм");
            SeriesCount = await database.GetCount("Сериал");
            AllCount = AnimeCount + FilmsCount + SeriesCount;
            OnPropertyChanged("AnimeCount");
            OnPropertyChanged("FilmsCount");
            OnPropertyChanged("SeriesCount");
            OnPropertyChanged("AllCount");

        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
