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
            _ = repository.SaveItemAsync(new Book(ID, Name, cover, pagesAmount, comment), ID);
            WeakReferenceMessenger.Default.Send(new AddTextItemMessage(this));
        });

        new public ICommand DeleteItem => new Command(
       execute: async () =>
       {
           _ = repository.DeleteItemAsync(new Book(ID, Name, cover, pagesAmount, comment));
           WeakReferenceMessenger.Default.Send(new DeleteTextItemMessage(this));
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
        }

        public BookViewModel(int ID, string Name, byte[] cover, IRepository repository, string Comment, int PagesAmount) : base(ID, Name, cover, repository)
        {
            this.Comment = Comment;
            this.PagesAmount = PagesAmount;
        }
    }
}
