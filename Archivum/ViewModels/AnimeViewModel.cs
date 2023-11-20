using Archivum.Logic;
using Archivum.Models;
using System.Windows.Input;

namespace Archivum.ViewModels
{
    public partial class AnimeViewModel : VideoLibraryViewModel
    {
        string comment;
        string waifu;
        int seriesCount;
        int seriesLength;


        public string Comment
        {
            get => comment;
            set
            {
                if (comment != value)
                {
                    comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }

        public int SeriesCount
        {
            get => seriesCount;
            set
            {
                if (seriesCount != value)
                {
                    seriesCount = value;
                    OnPropertyChanged(nameof(SeriesCount));
                }
            }
        }
        public int SeriesLength
        {
            get => seriesLength;
            set
            {
                if (seriesLength != value)
                {
                    seriesLength = value;
                    OnPropertyChanged(nameof(SeriesLength));

                }

            }
        }

        public string Waifu
        {
            get => waifu;
            set
            {
                if (waifu != value)
                {
                    waifu = value;
                    OnPropertyChanged(nameof(Waifu));
                }
            }
        }

        public new ICommand SaveItem => new Command(async () =>
            {
                _ = repository.SaveItemAsync(new Anime(ID, Name, Comment, cover, Waifu, SeriesCount, SeriesLength), ID);
                MessagingCenter.Send<VideoLibraryViewModel>(this, "Change video element");
                RefreshProperties();
            });

        public AnimeViewModel(IRepository repository) : base(repository) { }
        public AnimeViewModel(int ID, string Name, byte[] cover, IRepository repository, string Comment, int SeriesCount, int SeriesLength, string Waifu) : base(ID, Name, cover, repository)
        {
            this.Comment = Comment;
            this.SeriesCount = SeriesCount;
            this.SeriesLength = SeriesLength;
            this.Waifu = Waifu;
        }

        public override void RefreshProperties()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("Comment");
            OnPropertyChanged("Type");
            OnPropertyChanged("Cover");
            OnPropertyChanged("SeriesCount");
            OnPropertyChanged("SeriesLength");
            OnPropertyChanged("Waifu");
            OnPropertyChanged("anime");

        }
    }
}
