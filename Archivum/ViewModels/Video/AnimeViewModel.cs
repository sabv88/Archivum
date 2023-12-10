using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models.Video;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace Archivum.ViewModels.Video
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
            });

         public ICommand deleteItem => new Command(
            execute: async () =>
           {
               _ = repository.DeleteItemAsync(new Anime(ID, Name, Comment, cover, Waifu, SeriesCount, SeriesLength));
               WeakReferenceMessenger.Default.Send(new DeleteVideoItemMessage(this));
               await Shell.Current.GoToAsync($"..");
           });

        public AnimeViewModel(IRepository repository) : base(repository) { }
        public AnimeViewModel(int ID, string Name, byte[] cover, IRepository repository, string Comment, int SeriesCount, int SeriesLength, string Waifu) : base(ID, Name, cover, repository)
        {
            this.Comment = Comment;
            this.SeriesCount = SeriesCount;
            this.SeriesLength = SeriesLength;
            this.Waifu = Waifu;
        }

        public AnimeViewModel(Anime anime, IRepository repository) : base(repository)
        {
            ID = anime.ID;
            Name = anime.Name;
            cover = anime.Cover;
            SeriesCount = anime.SeriesCount;
            SeriesLength = anime.Serieslength;
            Waifu = anime.Waifu;
            Comment = anime.Comment;
        }
    }
}
