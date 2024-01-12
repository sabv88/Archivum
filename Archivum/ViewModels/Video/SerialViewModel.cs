using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models.Video;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace Archivum.ViewModels.Video
{
    public class SerialViewModel : VideoLibraryViewModel
    {
        string comment;
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

        public new ICommand SaveItem => new Command(async () =>
        {
            Repository repository = new Repository();
            _ = repository.SaveItemAsync(new Serial(ID, Name, comment, cover, status, estimation, seriesCount, seriesLength), ID);
        });

        public new ICommand DeleteItem => new Command(
       execute: async () =>
       {
           _ = repository.DeleteItemAsync(new Serial(ID, Name, comment, cover, status, estimation, seriesCount, seriesLength));
           SendMessageDelete(status, this);
           await Shell.Current.GoToAsync($"..");
       });

        public SerialViewModel(int ID, string Name, byte[] cover, int status, int estimation, IRepository repository, string Comment, int SeriesCount, int SeriesLength) : base(ID, cover, Name, status, estimation, repository)
        {
            this.Comment = Comment;
            this.SeriesCount = SeriesCount;
            this.SeriesLength = SeriesLength;
        }
        public SerialViewModel(IRepository repository) : base(repository) { this.repository = repository; }

        public SerialViewModel(Serial serial, IRepository repository) : base(repository)
        {
            ID = serial.ID;
            Name = serial.Name;
            cover = serial.Cover;
            SeriesCount = serial.SeriesCount;
            SeriesLength = serial.Serieslength;
            Comment = serial.Comment;
        }
    }
}
