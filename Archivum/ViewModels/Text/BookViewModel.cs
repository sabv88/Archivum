using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models.Text;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace Archivum.ViewModels.Text
{
    internal class BookViewModel : TextLibraryViewModel
    {
        string comment;
        int pagesAmount;
        string chaptersAmount;
        public string СhaptersAmount
        {
            get => chaptersAmount;
            set
            {
                if (chaptersAmount != value)
                {
                    chaptersAmount = value;
                    OnPropertyChanged(nameof(СhaptersAmount));
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

        public int PagesAmount
        {
            get => pagesAmount;
            set
            {
                if (pagesAmount != value)
                {
                    pagesAmount = value;
                    OnPropertyChanged(nameof(PagesAmount));
                }
            }
        }

        public new ICommand SaveItem => new Command(async () =>
        {
            _ = repository.SaveItemAsync(new Book(ID, Name, cover, status, estimation, pagesAmount, comment, chaptersAmount), ID);
        });

        new public ICommand DeleteItem => new Command(
       execute: async () =>
       {
           _ = repository.DeleteItemAsync(new Book(ID, Name, cover, status, estimation, pagesAmount, comment, chaptersAmount));
           SendMessageDelete(status, this);
           await Shell.Current.GoToAsync($"..");
       });

        public BookViewModel(IRepository repository) : base(repository) { }

        public BookViewModel(Book book, IRepository repository) : base(repository)
        {
            ID = book.ID;
            Name = book.Name;
            cover = book.Cover;
            PagesAmount = book.PagesAmount;
            Comment = book.Comment;
            this.Status = book.Status;
            this.Estimation = book.Estimation;
            this.СhaptersAmount = book.СhaptersAmount;
        }

        public BookViewModel(int ID, string Name, byte[] cover, int status, int estimation, IRepository repository, string Comment, int PagesAmount) : base(ID, Name, cover, status, estimation, repository)
        {
            this.Comment = Comment;
            this.PagesAmount = PagesAmount;
        }
    }
}
