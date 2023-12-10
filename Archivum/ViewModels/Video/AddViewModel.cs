using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models;
using Archivum.Models.Video;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace Archivum.ViewModels.Video
{
    public partial class AddViewModel : VideoLibraryViewModel
    {
        bool isEditingSeriesCount;
        bool isEditingSeriesLength;
        bool isEditingWaifu;
        string type;
        string comment;
        string waifu;
        int seriesCount;
        int seriesLength;

        public AddViewModel(IRepository repository) : base(repository)
        {
            isEditingSeriesCount = false;
            isEditingSeriesLength = false;
            isEditingWaifu = false;
        }

        public bool IsEditingSeriesCount
        {
            private set { SetProperty(ref isEditingSeriesCount, value); }
            get { return isEditingSeriesCount; }
        }

        public bool IsEditingSeriesLength
        {
            private set { SetProperty(ref isEditingSeriesLength, value); }
            get { return isEditingSeriesLength; }
        }

        public bool IsEditingWaifu
        {
            private set { SetProperty(ref isEditingWaifu, value); }
            get { return isEditingWaifu; }
        }
        public string Type
        {
            get => type;
            set
            {
                if (type != value)
                {
                    if (value == "Аниме")
                    {
                        IsEditingSeriesCount = true;
                        IsEditingSeriesLength = true;
                        IsEditingWaifu = true;
                        type = value;
                    }

                    if (value == "Сериал")
                    {
                        IsEditingSeriesCount = true;
                        IsEditingSeriesLength = true;
                        IsEditingWaifu = false;
                        type = value;

                    }

                    if (value == "Фильм")
                    {
                        IsEditingSeriesCount = false;
                        IsEditingSeriesLength = true;
                        IsEditingWaifu = false;
                        type = value;

                    }
                }
            }
        }

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

            if (Type == "Аниме")
            {
                var a = new Anime(0, Name, Comment, cover, Waifu, SeriesCount, SeriesLength);
                _ = await repository.SaveItemAsync(a, 0);
                WeakReferenceMessenger.Default.Send(new AddVideoItemMessage(new AnimeViewModel(a, repository)));
            }

            if (Type == "Сериал")
            {
                var a = new Serial(0, Name, Comment, cover, SeriesCount, SeriesLength);
                _ = await repository.SaveItemAsync(a, 0);
                WeakReferenceMessenger.Default.Send(new AddVideoItemMessage(new SerialViewModel(a, repository)));
            }

            if (Type == "Фильм")
            {
                var a = new Film(0, Name, Comment, cover, SeriesLength);
                _ = await repository.SaveItemAsync(a, 0);
                WeakReferenceMessenger.Default.Send(new AddVideoItemMessage(new FilmViewModel(a, repository)));
            }

            if (Type == null)
            {
                var a = new VideoMaterial(0, Name, cover);
                _ = await repository.SaveItemAsync(a, 0);
                WeakReferenceMessenger.Default.Send(new AddVideoItemMessage(this));
            }

        });
    }
}
